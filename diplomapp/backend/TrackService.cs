//https://docs.microsoft.com/ru-ru/dotnet/csharp/tutorials/console-webapiclient
//https://json2csharp.com/
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Http.Json;
using backend.Infrastructure.Database;
using backend.Infrastructure.DTO;
using Microsoft.EntityFrameworkCore;

namespace backend
{
    public class TrackService
    {
        private static readonly HttpClient client = new HttpClient();


        public async Task UpdateAsync(string artistName, CancellationToken token)
        {            
            for (int offset = 1; offset <= 6001; offset = offset + 200)
            {                
                var tracks = await GetTracksFromApiAsync(artistName,offset, token);
                SaveTracks(tracks);
                await Task.Delay(3500);
            }            
        }

        public IEnumerable<int> GetAvailabeYears()
        {
            IEnumerable<int> years;
            using (ApplicationContext db = new ApplicationContext())
            {
                db.MusicTracks.Load<MusicTrackDto>();
                years = db.MusicTracks.Select(t => t.ReleaseDate.Year).Distinct().OrderBy(t => t).ToList<int>();
            }
            return years;
        }

        public IEnumerable<InternalMusicTrack> GetTracksByYearsFromDb(int year)
        {
            IEnumerable<MusicTrackDto> tracks;
            using (ApplicationContext db = new ApplicationContext())
            {
                db.MusicTracks.Load<MusicTrackDto>();
                tracks = db.MusicTracks.Where(s => s.ReleaseDate.Year == year).Distinct().OrderByDescending(o => o.TrackPrice).ToList<MusicTrackDto>();
            }
            return Convert(tracks);
        }

        public IEnumerable<InternalMusicTrack> GetAllTracksFromDb()
        {
            IEnumerable<MusicTrackDto> tracks;
            using (ApplicationContext db = new ApplicationContext())
            {
                db.MusicTracks.Load<MusicTrackDto>();
                tracks = db.MusicTracks.OrderBy(o =>o.ReleaseDate.Year).Distinct().ToList<MusicTrackDto>();
            }
            return Convert(tracks);
        }

        private IEnumerable<InternalMusicTrack> Convert(IEnumerable<MusicTrackDto> tracks)
        {
            var result = new List<InternalMusicTrack>();
            foreach (var track in tracks)
            {
                var internalTrack = new InternalMusicTrack(track.Kind,
                    track.CollectionName,
                    track.TrackName,
                    track.CollectionPrice,
                    track.TrackPrice,
                    track.ReleaseDate,
                    track.TrackCount,
                    track.TrackNumber,
                    track.PrimaryGenreName);
                result.Add(internalTrack);
            }
            return result;
        }

        public async Task<IEnumerable<InternalMusicTrack>> GetTracksFromApiAsync(string artistName, int offset, CancellationToken token)
        {
            try
            {              

                var externalTracks = await client.GetFromJsonAsync<Root>($"https://itunes.apple.com/search?term={artistName}&limit={offset+199}&offset={offset}", token);
                var internalTracks = new List<InternalMusicTrack>();
                foreach (var externalTrack in externalTracks.results.Where(e => e.artistName == artistName))
                {
                    var internalTrack = new InternalMusicTrack(externalTrack.kind,
                        externalTrack.collectionName,
                        externalTrack.trackName,
                        externalTrack.collectionPrice,
                        externalTrack.trackPrice,
                        externalTrack.releaseDate,
                        externalTrack.trackCount,
                        externalTrack.trackNumber,
                        externalTrack.primaryGenreName);
                    internalTracks.Add(internalTrack);
                }

                return internalTracks;             
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return new List<InternalMusicTrack>();
            }

        }

        public void SaveTracks(IEnumerable<InternalMusicTrack> tracks)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                foreach (var track in tracks)
                {
                    var trackDto = new MusicTrackDto();
                    trackDto.Kind = track.Kind;
                    trackDto.CollectionName = track.CollectionName;
                    trackDto.TrackName = track.TrackName;
                    trackDto.CollectionPrice = track.CollectionPrice;
                    trackDto.TrackPrice = track.TrackPrice;
                    trackDto.ReleaseDate = track.ReleaseDate;
                    trackDto.TrackCount = track.TrackCount;
                    trackDto.TrackNumber = track.TrackNumber;
                    trackDto.PrimaryGenreName = track.PrimaryGenreName;
                    db.MusicTracks.Add(trackDto);
                }
                db.SaveChanges();
            }
        }

        public void DeleteAllTracks()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.MusicTracks.RemoveRange(db.MusicTracks);
                db.SaveChanges();
            }
        }

    }
}