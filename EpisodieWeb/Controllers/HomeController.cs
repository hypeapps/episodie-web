using System;
using Microsoft.AspNetCore.Mvc;
using EpisodieWeb.Dataproviders;

namespace EpisodieWeb.Controllers
{
    public class HomeController : Controller
    {
        // Definicja obiektu warstwy dostępu do danych
        TvShowRepository dataSource = new TvShowDataSource(Program.EPISODIE_API_USERNAME, Program.EPISODIE_API_PASSWORD);

        public IActionResult Index()
        {
            var mostPopular = dataSource.getMostPopular(0, 95);
            var topList = dataSource.getTopList(0, 116);
            /* Obecna data minus jeden miesiac  */
            DateTime fromDate = DateTime.UtcNow.Date.AddMonths(-1);
            var lastReleases = dataSource.getTvShowPremieres(0, 100, fromDate.ToString("yyyy-MM-dd"));
            ViewData["mostPopular"] = mostPopular;
            ViewData["topList"] = topList;
            ViewData["lastReleases"] = lastReleases;
            return View();
        }

        public IActionResult Detail(int id)
        {
            var entity = dataSource.getTvShowById(id);
            ViewData["entity"] = entity;
            return View();
        }

        public IActionResult Search(string searchString)
        {
            if (String.IsNullOrEmpty(searchString))
            {
                searchString = null;
            }
            else
            {
                var movies = dataSource.searchTvShowByQuery(searchString);
                ViewData["movies"] = movies;
            }
            return View();
        }
    }
}
