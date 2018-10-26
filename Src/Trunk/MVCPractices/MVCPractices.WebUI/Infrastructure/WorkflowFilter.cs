using System;
using System.Web.Mvc;
using System.Web.Routing;
using MVCPractices.Contracts.Services;
using MVCPractices.SharedKernel.Enums;
using Ninject;

namespace MVCPractices.WebUI.Infrastructure
{
    public class WorkflowFilter : FilterAttribute, IActionFilter
    {
        private int _highestCompleted;
        public int MinmunWorkflow { get; set; }
        public int CurrentWorkflow { get; set; }

        [Inject]
        public ICurrentUserService CurrentUserService { get; set; }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var tracker = filterContext.HttpContext.Session["Tracker"];

            if (tracker is null)
            {
                if (CurrentWorkflow != (int) WorkflowEnum.Profile)
                {
                    filterContext.Result = CreateRedirectResult("CreateProfile", "Profile");
                    return;
                }
                
            }
            else
            {
                if (tracker is Guid guid)
                {
                    var user = CurrentUserService.GetCurrentUser(guid.ToString());
                    _highestCompleted = user.HighestCompleted;

                }
                
            }
            
            

            if (MinmunWorkflow > _highestCompleted)
            {
                switch (_highestCompleted)
                {
                    case ((int)WorkflowEnum.Profile):
                        filterContext.Result = CreateRedirectResult("CreateProfile", "Profile");
                        break;
                    case ((int)WorkflowEnum.Address):
                        filterContext.Result = CreateRedirectResult("New", "Address");
                        break;
                    case ((int)WorkflowEnum.Mail):
                        filterContext.Result = CreateRedirectResult("NewMail", "Mail");
                        break;

                }
                
            }

        }

        private ActionResult CreateRedirectResult(string action, string controller)
        {
            return new RedirectToRouteResult(new RouteValueDictionary(new {action, controller}));
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var tracker = filterContext.HttpContext.Session["Tracker"];
            var requestType = filterContext.HttpContext.Request.RequestType;

            if (requestType.Equals("POST") && CurrentWorkflow > _highestCompleted)
            {
                if (tracker is Guid guid)
                {
                    var user = CurrentUserService.GetCurrentUser(guid.ToString());
                    user.HighestCompleted = CurrentWorkflow;
                }
                
            }
        }
    }
}