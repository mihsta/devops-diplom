//https://docs.microsoft.com/ru-ru/dotnet/csharp/tutorials/console-webapiclient
//https://json2csharp.com/
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Http.Json;

namespace backend
{
    public class TrackService
    {
        private static readonly HttpClient client = new HttpClient();


        public async Task<IEnumerable<InternalMusicTrack>> GetTracksAsync(string artistName, CancellationToken token)
        {
            try
            {                
                var externalTracks = await client.GetFromJsonAsync<Root>($"https://itunes.apple.com/search?term={artistName}&limit=200&offset=1", token);
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

    }
}