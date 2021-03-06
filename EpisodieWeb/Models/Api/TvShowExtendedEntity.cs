﻿using System;

namespace EpisodieWeb.Models.api
{   // Obiekt reprezentujący model JSON dla serialu z dodatkowymi informacjami.
    public class TvShowExtendedEntity
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

        public String summary { get; set; }

        public String premiere { get; set; }

        public String officialSite { get; set; }
    }
}
