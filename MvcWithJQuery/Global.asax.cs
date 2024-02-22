using MvcWithJQuery.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MvcWithJQuery
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //var exception = Server.GetLastError();
            //var httpException = exception as HttpException;
            //Response.Clear();
          
            //var routeData = new RouteData();
            //routeData.Values["controller"] = "Error";
            //routeData.Values["action"] = "HttpError404";
            //routeData.Values["error"] = exception;
            //if (httpException != null)
            //{
            //    Response.StatusCode = httpException.GetHttpCode();
            //    switch (Response.StatusCode)
            //    {
            //        case 403:
            //            routeData.Values["action"] = "HttpError403";
            //            break;
            //        case 404:
            //            //page not found error
            //            routeData.Values["action"] = "HttpError404";
            //            break;
            //        case 500:
            //            //server error
            //            routeData.Values["action"] = "HttpError500";
            //            break;
            //    }
            //    Server.ClearError();
            //}
            //IController errorsController = new ErrorController();
            //var rc = new RequestContext(new HttpContextWrapper(Context), routeData);
            //errorsController.Execute(rc);
        }

    }
}
