using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpisodieWeb.Models.api
{
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
