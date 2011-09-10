using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace NWiretap.Controllers
{
    public class NWiretapCounterController : Controller
    {
        public ActionResult Index()
        {
            return Json();
        }
    }
}