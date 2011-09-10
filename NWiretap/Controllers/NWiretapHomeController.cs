﻿using System.Web.Mvc;
using NWiretap.Measurement;

namespace NWiretap.Controllers
{
    public class NWiretapHomeController : Controller
    {
        /// <summary>
        /// Returns a list of all running instruments
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var instruments = InstrumentTracker.Instruments;
            
            return View("~/Plugin/NWiretap.dll/NWiretap.Views.NWiretapHome.Index.cshtml");
        }
    }
}