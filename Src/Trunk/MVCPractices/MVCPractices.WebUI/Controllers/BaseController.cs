using System;
using System.Web.Mvc;
using MVCPractices.WebUI.CustomActionResultHelpers;

namespace MVCPractices.WebUI.Controllers
{
    public abstract class BaseController: Controller
    {
        protected Guid Tracker { get; private set; }

        protected BaseController()
        {
            
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            // Demonstrate that you can get data from Session if your Action Method is needing data from Session
            // You won't have to repeat this in every Action Method.
            
            if (filterContext.HttpContext.Session["Tracker"] is Guid tracker)
            {
                Tracker = tracker;
            }
        }


        public CustomJsonResult CustomJsonResult(object data)
        {

            // This just demonstrates that you may do the same like return view()
            // on Controller which inherits from this BaseController

            return new CustomJsonResult(data);


        }





        
    }
}