using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpisodieWeb.Models.Api
{
    public class TvShowPremiere
    {

        private String tvShowApiId { get; set; }

        private String imdbId { get; set; }

        private String name { get; set; }

        private String officialSite { get; set; }

        private String network { get; set; }

        private String genre { get; set; }

        private long runtime { get; set; }

        private int fullRuntime { get; set; }

        private int episodeOrder { get; set; }

        private String status { get; set; }

        private String premiere { get; set; }

        private String summary { get; set; }

        private String imageMedium { get; set; }

        private String imageOriginal { get; set; }
    }
}
