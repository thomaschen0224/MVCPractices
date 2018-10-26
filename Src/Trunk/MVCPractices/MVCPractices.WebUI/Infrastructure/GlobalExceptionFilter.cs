using System.Text;
using NLog;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCPractices.WebUI.Infrastructure
{

    public class GlobalExceptionFilter: FilterAttribute, IExceptionFilter
    {

        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        
        
        public void OnException(ExceptionContext filterContext)
        {
            if(filterContext.ExceptionHandled)
                return;

            var message = filterContext.Exception.Message;
            var stackTrace = filterContext.Exception.StackTrace;
            var controllerName = filterContext.Controller.GetType().Name;
            var targetResultName = filterContext.Result.GetType().Name;
            var userAgent = filterContext.HttpContext.Request.UserAgent;

            var logBuilder = new StringBuilder();
            logBuilder.AppendLine($"Message: {message}");
            logBuilder.AppendLine($"Stack Trace: {stackTrace}");
            logBuilder.AppendLine($"Controller: {controllerName}");
            logBuilder.AppendLine($"Target: {targetResultName}");
            logBuilder.AppendLine($"User Agent: {userAgent}");
            
            _logger.Info(logBuilder.ToString);
            
            filterContext.ExceptionHandled = true;

            filterContext.Result = CreateRedirectResult("Index", "Error");


        }
        
        
        private ActionResult CreateRedirectResult(string action, string controller)
        {
            return new RedirectToRouteResult(new RouteValueDictionary(new {action, controller}));
        }
        
        
    }
}