using System.Collections.Generic;

namespace WebAPI.Test.Model
{
    public class Artist
    {
        public ExternalUrls ExternalUrls { get; set; }
        public Followers Followers { get; set; }
        public IEnumerable<string> Genres { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public IEnumerable<Image> Images { get; set; }
        public string Name { get; set; }
        public int Popularity { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }
}
