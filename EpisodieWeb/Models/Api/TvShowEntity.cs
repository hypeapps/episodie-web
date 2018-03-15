using System;

namespace EpisodieWeb.Models.api
{
    // Obiekt reprezentujący model JSON dla serialu zawierający podstawowe informacje.
    public class TvShowEntity
    {
        public int tvShowApiId { get; set; }

        public String imdbId { get; set; }

        public String name { get; set; }
        
        public String status { get; set; }

        public String network { get; set; }

        public long runtime { get; set; }

        public long fullRuntime { get; set; }

        public String genre { get; set; }

        public String imageMedium { get; set; }

        public String imageOriginal { get; set; }
    }
}
