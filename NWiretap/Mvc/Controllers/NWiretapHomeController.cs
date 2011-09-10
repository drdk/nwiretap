using System.Web.Mvc;
using NWiretap.Measurement;

namespace NWiretap.Mvc.Controllers
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
            
            return View(instruments);
        }
    }
}