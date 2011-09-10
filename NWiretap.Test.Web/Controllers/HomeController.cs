﻿using System.Web.Mvc;
using NWiretap.Instumentation;

namespace NWiretap.Test.Web.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ICounter Cnt = Counter.Create("test counter", 10000);

        public ActionResult Index()
        {
            Cnt.Increment();

            return View();
        }

    }
}
