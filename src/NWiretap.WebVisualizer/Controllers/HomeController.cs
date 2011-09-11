using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using NWiretap.Instruments.Logger;
using NWiretap.Instruments.Ticker;
using NWiretap.Instruments.Timer;

namespace NWiretap.WebVisualizer.Controllers
{
    public class HomeController : Controller
    {
        private static readonly IMeter Ticker = Instrument.Ticker("Some counter", 3000);
        private static readonly IInvocationTimer Timer = Instrument.Timer("Some timer", 3000);
        private static readonly ILogger Logger = Instrument.Logger("SomeLogger", 20);
        
        public ActionResult Index()
        {
            Ticker.Tick();
            var s = Timer.Time(() =>
                                   {
                                       return GetStrings();
                                   });

            Logger.Log("Index was hit");
            return View();
        }

        public IEnumerable<string> GetStrings()
        {
            Thread.Sleep(300);
            return null;
        }
    }
}