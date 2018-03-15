using EpisodieWeb.Models.api;
using EpisodieWeb.Models.Api;
using System.Collections.Generic;

namespace EpisodieWeb.Controllers
{
    // Wzorzec repozytorium definujący zasoby warstwy dostępu do danych.
    interface TvShowRepository
    {
        Pageable<TvShowEntity> getMostPopular(int page, int size);

        Pageable<TvShowEntity> getTopList(int page, int size);

        Pageable<TvShowPremiere> getTvShowPremieres(int page, int size, string fromDate);

        List<TvShowEntity> searchTvShowByQuery(string query);

        TvShowExtendedEntity getTvShowById(int id);
    }
}
