using System.Web.Mvc;
using System.Web.Routing;

namespace NWiretap
{
    public static class NWiretapIntegrator
    {
        public static void RegisterNWirewapRoutes(RouteCollection routeCollection, string urlPrefix = "")
        {
            var ns = typeof (NWiretapIntegrator).Namespace;
            var url = urlPrefix + "nwiretap";
            routeCollection.MapRoute("NWireTap", url, new
                                                                 {
                                                                     controller = "NWiretapHome",
                                                                     action = "index",
                                                                     id = UrlParameter.Optional
                                                                 });
        }
    }
}
