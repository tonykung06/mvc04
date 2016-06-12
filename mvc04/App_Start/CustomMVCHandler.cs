using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace mvc04.App_Start
{
    class CustomMVCHandler : IHttpHandler
    {
        public RequestContext RequestContext { get; set; }
        public CustomMVCHandler(RequestContext requestContext)
        {
            this.RequestContext = requestContext;
        }

        public bool IsReusable
        {
            get { return false; }
        }

        void IHttpHandler.ProcessRequest(HttpContext context)
        {
            string controllerId = RequestContext.RouteData.GetRequiredString("controller");
            IController controller = null;
            IControllerFactory factory = null;

            try
            {
                factory = ControllerBuilder.Current.GetControllerFactory();
                controller = factory.CreateController(RequestContext, controllerId);

                if (controller != null)
                {
                    controller.Execute(RequestContext);
                }
            }
            finally
            {
                factory.ReleaseController(controller);
            }
        }
    }
}
