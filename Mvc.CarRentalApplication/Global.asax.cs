﻿using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using log4net;

namespace Mvc.CarRentalApplication
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode,
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //This will register the Unity with Mvc
            Bootstrapper.Initialise();
            log4net.Config.XmlConfigurator.Configure();
        }

        private void Application_Error(object sender, EventArgs e)
        {
            var error = Server.GetLastError();
            if (error != null)
            {
                var stackTrace = error.StackTrace;
                Response.Write(stackTrace);
            }
        }
    }
}