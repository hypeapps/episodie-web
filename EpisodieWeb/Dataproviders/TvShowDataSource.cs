using EpisodieWeb.Controllers;
using EpisodieWeb.Models.api;
using EpisodieWeb.Models.Api;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;

namespace EpisodieWeb.Dataproviders
{
    // Warstwa dostępu do danych implementujący repozytorium oraz połączenie z episodie API.
    public class TvShowDataSource : TvShowRepository
    {
        private string username { get; set; }

        private string password { get; set; }

        private const string BASE_URL = "https://episodie.ct8.pl/api";

        public TvShowDataSource(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        /// <param name="page">Numer strony</param>
        /// <param name="size">Ilość elementów</param>
        /// <returns>Zwraca paginowaną listę najbardziej popularnych seriali</returns>
        public Pageable<TvShowEntity> getMostPopular(int page, int size)
        {
            var request = new RestRequest();
            request.Resource = "tvshow/mostpopular";
            request.AddParameter("size", size, ParameterType.QueryString);
            request.AddParameter("page", page, ParameterType.QueryString);
            return Execute<Pageable<TvShowEntity>>(request);
        }

        /// <param name="page">Numer strony</param>
        /// <param name="size">Ilość elementów</param>
        /// <returns>Zwraca paginowaną listę top 100 seriali</returns>
        public Pageable<TvShowEntity> getTopList(int page, int size)
        {
            var request = new RestRequest();
            request.Resource = "tvshow/toplist";
            request.AddParameter("size", size, ParameterType.QueryString);
            request.AddParameter("page", page, ParameterType.QueryString);
            return Execute<Pageable<TvShowEntity>>(request);
        }

        /// <param name="id">Identyfikator filmu</param>
        /// <returns>Zwraca serial dla podanego identyfikatora.</returns>
        public TvShowExtendedEntity getTvShowById(int id)
        {
            var request = new RestRequest();
            request.Resource = "tvshow/get/" + id;
            return Execute<TvShowExtendedEntity>(request);
        }

        /// <param name="query">Zapytanie</param>
        /// <returns>Zwraca serial dla podanego zapytania.</returns>
        public List<TvShowEntity> searchTvShowByQuery(string query)
        {
            var request = new RestRequest();
            request.Resource = "tvshow/search";
            request.AddParameter("query", query, ParameterType.QueryString);
            return Execute<List<TvShowEntity>>(request);
        }

        /// <param name="page">Numer strony</param>
        /// <param name="size">Ilość elementów</param>
        /// <param name="fromDate">Data od której mają zaczynać się premiery seriali.</param>
        /// <returns>Zwraca paginowaną listę seriali od wybranej daty premiery</returns>
        public Pageable<TvShowPremiere> getTvShowPremieres(int page, int size, string fromDate)
        {
            var request = new RestRequest();
            request.Resource = "tvshow/premieres/series";
            request.AddParameter("size", size, ParameterType.QueryString);
            request.AddParameter("page", page, ParameterType.QueryString);
            request.AddParameter("fromDate", fromDate, ParameterType.QueryString);
            return Execute<Pageable<TvShowPremiere>>(request);
        }

        /// <summary>
        /// Metoda wykonująca zapytanie REST. W przypadku niepowodzenia rzuca wyjątek.
        /// </summary>
        /// <typeparam name="T">Typ zwracanego modelu</typeparam>
        /// <param name="request">Zapytanie REST</param>
        /// <returns>Model zapytania REST</returns>
        public T Execute<T>(RestRequest request) where T : new()
        {
            var httpClient = new RestClient();
            httpClient.BaseUrl = new Uri(BASE_URL);
            httpClient.Authenticator = new HttpBasicAuthenticator(username, password);
            var response = httpClient.Execute<T>(request);
            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var errorException = new ApplicationException(message, response.ErrorException);
                throw errorException;
            }
            return response.Data;
        }

    }
}
