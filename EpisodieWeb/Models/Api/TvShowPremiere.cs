using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpisodieWeb.Models.Api
{
    public class TvShowPremiere
    {

        public String tvShowApiId { get; set; }

        public String imdbId { get; set; }

        public String name { get; set; }

        public String officialSite { get; set; }

        public String network { get; set; }

        public String genre { get; set; }

        public long runtime { get; set; }

        public int fullRuntime { get; set; }

        public int episodeOrder { get; set; }

        public String status { get; set; }

        public String premiere { get; set; }

        public String summary { get; set; }

        public String imageMedium { get; set; }

        public String imageOriginal { get; set; }
    }
}
