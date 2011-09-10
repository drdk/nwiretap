using System.Web.Mvc;

namespace NWiretap.WebVisualizer
{
    public class Routes : AreaRegistration
    {
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "NWireTap_defaultRoute",
                "nwiretap/{controller}/{action}/{id}",
                new { controller = "NWiretapHome", action = "index", id = UrlParameter.Optional });
        }

        public override string AreaName
        {
            get { return "nwiretap"; }
        }
    }
}
