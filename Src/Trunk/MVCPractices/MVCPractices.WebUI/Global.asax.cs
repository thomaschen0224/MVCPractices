using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MVCPractices.WebUI.Infrastructure;
using MVCPractices.WebUI.NinjectBindings;
using Ninject;
using Ninject.Web.Common.WebHost;
using NLog;

namespace MVCPractices.WebUI
{
    public class MvcApplication : NinjectHttpApplication
    {

        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        protected override void OnApplicationStarted()
        {

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["ActiveTheme"]))
            {
                var activeTheme = ConfigurationManager.AppSettings["ActiveTheme"];
                ViewEngines.Engines.Insert(0, new ThemeViewEngine(activeTheme));
            }

            base.OnApplicationStarted();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }
        
        protected override IKernel CreateKernel()
        {
            return new StandardKernel(new BindingModules());
        }

        protected void Application_Error()
        {

            // This is just application wide exception error handling.
            // You may get error information. However, Exception Filter will carry more useful information about the error.
            //

            var ex = Server.GetLastError();
            _logger.Error(ex);

            HttpContext.Current.Response.RedirectToRoute("Default",
                new RouteValueDictionary(new {controller = "Error", action = "Index"}));

        }


    }
}
