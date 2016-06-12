using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace mvc04.App_Start
{
    public class MyRouteHandler : MvcRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            string UA = requestContext.HttpContext.Request.Headers["User-Agent"];

            //string ipAddress = requestContext.HttpContext.Request.ServerVariables["REMOTE_ADDR"];

            if (UA.Contains("Chrome"))
            {
                requestContext.RouteData.Values["action"] = "CAction";
            }

            return base.GetHttpHandler(requestContext);
        }
    }
}
