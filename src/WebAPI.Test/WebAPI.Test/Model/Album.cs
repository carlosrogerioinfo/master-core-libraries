using System.Collections.Generic;

namespace WebAPI.Test.Model
{
    public class Album
    {
        public string AlbumType { get; set; }
        public IEnumerable<Artist> Artists { get; set; }
        public IEnumerable<Copyright> Copyrights { get; set; }
        public ExternalIds ExternalIds { get; set; }
        public ExternalUrls ExternalUrls { get; set; }
        public IEnumerable<object> Genres { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public IEnumerable<Image> Images { get; set; }
        public string Label { get; set; }
        public string Name { get; set; }
        public int Popularity { get; set; }
        public string ReleaseDate { get; set; }
        public string ReleaseDatePrecision { get; set; }
        public int TotalTracks { get; set; }
        public Tracks Tracks { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }
}
