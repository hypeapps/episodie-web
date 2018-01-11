using EpisodieWeb.Controllers;
using EpisodieWeb.Models.api;
using EpisodieWeb.Models.Api;
using Microsoft.Extensions.Logging;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EpisodieWeb.Dataproviders
{
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

        public Pageable<TvShowEntity> getMostPopular(int page, int size)
        {
            var request = new RestRequest();
            request.Resource = "tvshow/mostpopular";
            request.AddParameter("size", size, ParameterType.QueryString);
            request.AddParameter("page", page, ParameterType.QueryString);
            return Execute<Pageable<TvShowEntity>>(request);
        }

        public Pageable<TvShowEntity> getTopList(int page, int size)
        {
            var request = new RestRequest();
            request.Resource = "tvshow/toplist";
            request.AddParameter("size", size, ParameterType.QueryString);
            request.AddParameter("page", page, ParameterType.QueryString);
            return Execute<Pageable<TvShowEntity>>(request);
        }

        public TvShowExtendedEntity getTvShowById(int id)
        {
            var request = new RestRequest();
            request.Resource = "tvshow/get/" + id;
            return Execute<TvShowExtendedEntity>(request);
        }

        public List<TvShowEntity> searchTvShowByQuery(string query)
        {
            var request = new RestRequest();
            request.Resource = "tvshow/search";
            request.AddParameter("query", query, ParameterType.QueryString);
            return Execute<List<TvShowEntity>>(request);
        }

        public Pageable<TvShowPremiere> getTvShowPremieres(int page, int size, string fromDate)
        {
            var request = new RestRequest();
            request.Resource = "tvshow/premieres/series";
            request.AddParameter("size", size, ParameterType.QueryString);
            request.AddParameter("page", page, ParameterType.QueryString);
            request.AddParameter("fromDate", fromDate, ParameterType.QueryString);
            return Execute<Pageable<TvShowPremiere>>(request);
        }

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
            Console.WriteLine("CHUUUUUUUUUUUUUUUUUUUUUUUUUUUJ" + response.StatusCode);
            return response.Data;
        }

    }
}
