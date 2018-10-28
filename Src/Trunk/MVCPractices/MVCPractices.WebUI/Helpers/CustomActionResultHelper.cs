using System.Web.Mvc;
using System.Web.Routing;

namespace MVCPractices.WebUI.Helpers
{
    public class CustomActionResultHelper
    {



        public static ActionResult CreateRedirectResult(string action, string controller)
        {
            return new RedirectToRouteResult(new RouteValueDictionary(new { action, controller }));
        }

    }
}