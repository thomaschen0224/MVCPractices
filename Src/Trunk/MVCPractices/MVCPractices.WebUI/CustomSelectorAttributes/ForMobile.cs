using System.Reflection;
using System.Web.Mvc;

namespace MVCPractices.WebUI.CustomSelectorAttributes
{
    public class ForMobile : ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {

            return controllerContext.HttpContext.Request.Headers["x-mobile"] != null;


        }
    }
}