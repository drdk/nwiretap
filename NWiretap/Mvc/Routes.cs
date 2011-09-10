using System.Web.Mvc;

namespace NWiretap.Mvc
{
    public class Routes : AreaRegistration
    {
        public override void RegisterArea(AreaRegistrationContext context)
        {
            //Register our hosting provider
            System.Web.Hosting.HostingEnvironment.RegisterVirtualPathProvider(new NWiretapResourceProvider());

            //Map routes
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
