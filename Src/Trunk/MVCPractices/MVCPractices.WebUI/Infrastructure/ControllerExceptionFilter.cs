using System.Web.Mvc;
using System.Web.Routing;
using NLog;

namespace MVCPractices.WebUI.Infrastructure
{
    public class ControllerExceptionFilter: FilterAttribute, IExceptionFilter
    {

        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public void OnException(ExceptionContext filterContext)
        {



            var ex = filterContext.Exception;
            _logger.Info("This is handled by ControllerExceptoinFilter");
            _logger.Info(ex.Message);

            filterContext.ExceptionHandled = true;

            filterContext.Result = CreateRedirectResult("Index", "Error");


        }


        private ActionResult CreateRedirectResult(string action, string controller)
        {
            return new RedirectToRouteResult(new RouteValueDictionary(new { action, controller }));
        }


    }
}