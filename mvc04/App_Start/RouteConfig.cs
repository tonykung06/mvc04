using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using mvc04.App_Start;

namespace mvc04
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "TestN",
                url: "Default/Action/{i1}",
                defaults: new
                {
                    controller = "Default",
                    action = "ActionN"
                },
                constraints: new
                {
                    i1 = @"\d+"
                }
            );

            routes.MapRoute(
                name: "TestSS",
                url: "Default/Action/{s1}-{s2}",
                defaults: new
                {
                    controller = "Default",
                    action = "ActionSS"
                }
            );

            routes.MapRoute(
                "TestS",
                "Default/Action/{i1}",
                new
                {
                    controller = "Default",
                    action = "ActionS"
                }
            );

            routes.MapRoute(
                name: "Test",
                url: "Default/Action",
                defaults: new
                {
                    controller = "Default",
                    action = "Action"
                }
            ).RouteHandler = new App_Start.MyRouteHandler();

            routes.IgnoreRoute("Default/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

