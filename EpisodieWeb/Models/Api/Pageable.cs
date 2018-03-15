using System.Collections.Generic;

namespace EpisodieWeb.Models.Api
{
    // Klasa generyczna opakowująca logikę paginacji.
    public class Pageable<T>
    {
        public List<T> content { get; set; }

        public bool last { get; set; }

        public int number { get; set; }

        public int totalPages { get; set; }

        public int totalElements { get; set; }
    }
}
