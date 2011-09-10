using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

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
            var instruments = InstrumentTracker.Instruments.Select(a => new Model.Instrument
                                                                                    {
                                                                                        InstrumentID = a.InstrumentID,
                                                                                        InstrumentIdent = a.Instrument.InstrumentIdent,
                                                                                        Measurement = a.Instrument.GetMeasurement()
                                                                                    });

            return Json(instruments, JsonRequestBehavior.AllowGet);
        }
    }
}