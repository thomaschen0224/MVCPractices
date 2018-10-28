using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
using MVCPractices.Models;

namespace MVCPractices.WebUI.CustomAuthentication
{
    public class BasicAuthen : FilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            var authorizedUser = filterContext.HttpContext.Session["AuthorizedUser"];
            if (authorizedUser != null)
            {
                if (authorizedUser is CurrentUser user)
                {
                    if (user.IsAuthorized)
                        return;
                }
            }


            filterContext.Result = CreateRedirectResult("Index", "Login");
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
        }


        private ActionResult CreateRedirectResult(string action, string controller)
        {
            return new RedirectToRouteResult(new RouteValueDictionary(new {action, controller}));
        }
    }
}