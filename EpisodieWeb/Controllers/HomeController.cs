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
            /* Obecna data minus pół roku  */
            DateTime dateTime = DateTime.UtcNow.Date;
            var firstRelease = dateTime.AddMonths(-6);

            TvShowRepository dataSource = new TvShowDataSource("EpisodieAndroidClient", "123#261261&p8p6992");
            var mostPopular = dataSource.getMostPopular(0, 95);
            var topList = dataSource.getTopList(0, 116);
            var lastReleases = dataSource.getTvShowPremieres(0, 100, firstRelease.ToString("yyyy-MM-dd")); /* Premiery do pół roku wstecz */

            /*
            System.Diagnostics.Debug.WriteLine("HELLO");
            System.Diagnostics.Debug.WriteLine(mostPopular.totalElements);
            System.Diagnostics.Debug.WriteLine(topList.totalElements);
            */

            ViewData["mostPopular"] = mostPopular;
            ViewData["topList"] = topList;
            ViewData["lastReleases"] = lastReleases;
            return View();
        }

        public IActionResult Detail(int id) {

            TvShowRepository dataSource = new TvShowDataSource("EpisodieAndroidClient", "123#261261&p8p6992");
            var entity = dataSource.getTvShowById(id);

         //   System.Diagnostics.Debug.WriteLine("HELLO2");
         //   System.Diagnostics.Debug.WriteLine(entity.imageOriginal);

            ViewData["entity"] = entity;
            return View();

        }
    }
}
