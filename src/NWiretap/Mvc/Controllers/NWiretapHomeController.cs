using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;

namespace NWiretap.Mvc.Controllers
{
    public class NWiretapHomeController : Controller
    {
        /// <summary>
        /// Returns a list of all running instruments
        /// </summary>
        /// <returns></returns>
        [CrossDomainXhr]
        [OutputCache(Location = OutputCacheLocation.None)]
        public ActionResult Index()
        {
            var instruments = InstrumentTracker.Instruments.Select(a => new Model.Instrument
                                                                                    {
                                                                                        InstrumentID = a.InstrumentID,
                                                                                        InstrumentIdent = a.Instrument.InstrumentIdent,
                                                                                        InstrumentType = a.Instrument.InstrumentType,
                                                                                        ImplementorType = a.Instrument.OwningType.Name,
                                                                                        InstrumentGroup = a.Instrument.InstrumentGroup,
                                                                                        Measurement = a.Instrument.GetMeasurement()
                                                                                    }).ToArray();

            return Json(instruments.GroupBy(a => a.InstrumentGroup)
                .Select(a => new { 
                    GroupName = a.Key, 
                    Instruments = a.OrderBy(b => b.ImplementorType).ThenBy(b => b.InstrumentIdent).ToArray() 
                }).OrderBy(a => a.GroupName).ToArray(),
                JsonRequestBehavior.AllowGet);
        }
    }

    public class CrossDomainXhrAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", "*");
            filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Request-Method", "POST, GET, OPTIONS");

            if (filterContext.RequestContext.HttpContext.Request.HttpMethod.ToUpper() == "OPTIONS")
            {
                filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Headers", filterContext.RequestContext.HttpContext.Request.Headers["Access-Control-Request-Headers"]);
                filterContext.RequestContext.HttpContext.Response.AddHeader("X-DR-Request-Terminated-By", "CrossDomainXhr-OPTIONS");
                filterContext.Result = new ContentResult();
            }

            base.OnActionExecuting(filterContext);
        }
    }
}