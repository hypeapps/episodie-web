using EpisodieWeb.Models.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpisodieWeb.Models.Api
{
    public class Pageable<T>
    {
        public List<T> content { get; set; }

        public bool last { get; set; }

        public int number { get; set; }

        public int totalPages { get; set; }

        public int totalElements { get; set; }
    }
}
