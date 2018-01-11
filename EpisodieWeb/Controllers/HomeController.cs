using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EpisodieWeb.Models;
using EpisodieWeb.Dataproviders;

namespace EpisodieWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Console.WriteLine("HELLO");
            TvShowRepository dataSource = new TvShowDataSource("EpisodieAndroidClient", "123#261261&p8p6992");
            var elo = dataSource.getTvShowPremieres(0, 5, "2017-12-01");
           Console.WriteLine("" + elo.totalElements);
            return View();
        }
    }
}
