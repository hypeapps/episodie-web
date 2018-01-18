using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EpisodieWeb.Models;
using EpisodieWeb.Dataproviders;
using System.Linq;

namespace EpisodieWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            /* Obecna data minus jeden miesiac  */
            DateTime dateTime = DateTime.UtcNow.Date;
            var firstRelease = dateTime.AddMonths(-1);

            TvShowRepository dataSource = new TvShowDataSource("EpisodieAndroidClient", "123#261261&p8p6992");
            var mostPopular = dataSource.getMostPopular(0, 95);
            var topList = dataSource.getTopList(0, 116);
            var lastReleases = dataSource.getTvShowPremieres(0, 100, firstRelease.ToString("yyyy-MM-dd")); /* Premiery do miesiac  wstecz */

            ViewData["mostPopular"] = mostPopular;
            ViewData["topList"] = topList;
            ViewData["lastReleases"] = lastReleases;
            return View();
        }

        public IActionResult Detail(int id) {

            TvShowRepository dataSource = new TvShowDataSource("EpisodieAndroidClient", "123#261261&p8p6992");
            var entity = dataSource.getTvShowById(id);

            ViewData["entity"] = entity;
            return View();

        }

        public IActionResult Search(string searchString)
        {
            TvShowRepository dataSource = new TvShowDataSource("EpisodieAndroidClient", "123#261261&p8p6992");
            if (String.IsNullOrEmpty(searchString))
                searchString = null;
            else
            {
                var movies = dataSource.searchTvShowByQuery(searchString);
                ViewData["movies"] = movies;
            }
            return View();

        }
    }
}
