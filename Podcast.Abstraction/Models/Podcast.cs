using System;

namespace Podcast.Abstraction.Models
{
    public class PodcastModel
    {
        public string UrlAdress { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Interval { get; set; }

        public int numberOfItems { get; set; }

        public ItemDescription[] items;

        public DateTime LastExecuted;
        public string Category { get; set; }

    }
}
