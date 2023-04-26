using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BaseBall_Stats
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "Stats",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "HittingStats", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "CreatePositionPlayer",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Home", action = "CreatePositionPlayer", id = UrlParameter.Optional }
          );
            routes.MapRoute(
              name: "CreatePitchingPlayer",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Home", action = "CreatePitchingPlayer", id = UrlParameter.Optional }
          );
        }
    }
}
