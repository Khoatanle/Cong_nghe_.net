using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebAppCK.Controllers;

namespace WebAppCK
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Product", "{type}/{meta}",
                new { controller = "Product", action = "toProduct", meta = UrlParameter.Optional },
                new RouteValueDictionary
                {
                    {"type", "san-pham" }
                },
                new[] { "WebAppCK.Controllers" });

            routes.MapRoute("Detail", "{type}/{meta}/{id}",
                new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
                new RouteValueDictionary
                {
                    {"type", "san-pham" }
                },
                new[] { "WebAppCK.Controllers" });

            routes.MapRoute("Contact", "{type}",
                new { controller = "Contact", action = "getContact", id = UrlParameter.Optional },
                new RouteValueDictionary
                {
                    {"type", "lien-he" }
                },
                new[] { "WebAppCK.Controllers" });

            routes.MapRoute("Discount", "{type}",
                new { controller = "Discount", action = "getDiscount", id = UrlParameter.Optional },
                new RouteValueDictionary
                {
                    {"type", "khuyen-mai" }
                },
                new[] { "WebAppCK.Controllers" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Default", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
