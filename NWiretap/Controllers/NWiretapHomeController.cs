using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
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
            var instruments = GetType().Assembly.GetTypes().Where(a => (typeof (IInstrument).IsAssignableFrom(a)) && a.IsClass);


            return null;
        }
    }
}