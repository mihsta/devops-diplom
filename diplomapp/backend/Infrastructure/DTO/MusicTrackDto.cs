namespace backend.Infrastructure.DTO
{
    public class MusicTrackDto
    {
        public long Id { get; set; }
        public string Kind { get; set; }
        public string CollectionName { get; set; }
        public string TrackName { get; set; }
        public double CollectionPrice { get; set; }
        public double TrackPrice { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int TrackCount { get; set; }
        public int TrackNumber { get; set; }
        public string PrimaryGenreName { get; set; }
    }
}
