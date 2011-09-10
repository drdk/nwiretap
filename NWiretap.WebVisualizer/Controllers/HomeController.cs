using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NWiretap.Instumentation;

namespace NWiretap.WebVisualizer.Controllers
{
    public class HomeController : Controller
    {
        private static ICounter Counter = Instumentation.Counter.Create("Some counter", 10000);
        public ActionResult Index()
        {
            Counter.Increment();
            return View();
        }
    }
}
