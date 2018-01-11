using EpisodieWeb.Models.api;
using EpisodieWeb.Models.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpisodieWeb.Controllers
{
    interface TvShowRepository
    {
        Pageable<TvShowEntity> getMostPopular(int page, int size);

        Pageable<TvShowEntity> getTopList(int page, int size);

        Pageable<TvShowPremiere> getTvShowPremieres(int page, int size, string fromDate);

        List<TvShowEntity> searchTvShowByQuery(string query);

        TvShowExtendedEntity getTvShowById(int id);
    }
}
