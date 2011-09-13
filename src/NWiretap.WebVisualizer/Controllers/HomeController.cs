using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using NWiretap.Instruments.Logger;
using NWiretap.Instruments.Meter;
using NWiretap.Instruments.Timer;

namespace NWiretap.WebVisualizer.Controllers
{
    public class HomeController : Controller
    {
        private static readonly IMeter Meter = Instrument.Meter(typeof(HomeController), "General performance", "Index hits", 3000);
        private static readonly IInvocationTimer Timer = Instrument.Timer(typeof(HomeController), "General performance", "Database fetch", 3000);
        private static readonly ILogger Logger = Instrument.Logger(typeof(HomeController), "General logging", "Log output", 20);
        
        public ActionResult Index(string id)
        {
            if(string.IsNullOrEmpty(id))
            {
                return RedirectToAction("PickServers");
            }

            var servers = id.Replace("\r", "").Split("\r\n".ToCharArray());
            var serverList = new List<object>();
            foreach (var split in servers.Select(server => server.Split("=".ToCharArray())))
            {
                serverList.Add(new
                                   {
                                       name = split[0],
                                       url = split[1]
                                   });
            }

            var jsSerializer = new JavaScriptSerializer();
            ViewBag.ServerList = jsSerializer.Serialize(serverList);

            Meter.Tick();
            var s = Timer.Time(() => GetStrings());

            Logger.Log("Index was hit");
            return View();
        }

        public ActionResult PickServers()
        {
            return View();
        }

        public IEnumerable<string> GetStrings()
        {
            return null;
        }
    }
}