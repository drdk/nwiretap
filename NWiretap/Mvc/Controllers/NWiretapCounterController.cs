using System.Linq;
using System.Web.Mvc;
using NWiretap.Instumentation;
using NWiretap.Measurement;

namespace NWiretap.Mvc.Controllers
{
    public class NWiretapCounterController : Controller
    {
        public ActionResult Index(int instrumentId)
        {
            var instrument = InstrumentTracker.Instruments.Single(a => a.InstrumentID == instrumentId) as ICounter;
            return Json(instrument, JsonRequestBehavior.AllowGet);
        }
    }
}