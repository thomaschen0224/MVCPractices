using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MVCPractices.Models;
using MVCPractices.SharedKernel.Enums;

namespace MVCPractices.WebUI.CustomAuthentication
{
    public class AuthorizedRole : AuthorizeAttribute
    {

        public AuthorizedRoles AuthorizedRoles { get; set; }

        public AuthorizedRole()
        {
            
            
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["AuthorizedUser"] is CurrentUser user)
            {
                if (user.IsAuthorized && user.AuthorizedRoles == AuthorizedRoles)
                    return true;
            }

            return false;

        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = CreateRedirectResult("UnAuthorized", "Error");
        }

        private ActionResult CreateRedirectResult(string action, string controller)
        {
            return new RedirectToRouteResult(new RouteValueDictionary(new { action, controller }));
        }

    }
}