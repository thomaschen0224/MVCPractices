using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCPractices.WebUI.CustomSelectorAttributes;
using MVCPractices.WebUI.Infrastructure;

namespace MVCPractices.WebUI.Controllers
{
    [ControllerExceptionFilter]
    [WorkflowFilter(MinmunWorkflow = 0, CurrentWorkflow = 10)]
    public class ProfileController : Controller
    {
        
        public ActionResult CreateProfile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveProfile()
        {
            var guid = Guid.NewGuid();
            Session["Tracker"] = guid;

            return RedirectToAction("New", "Address");
        }


        public ActionResult GetError()
        {

            //var number = int.Parse("test");

            return View();

        }

        [ActionName("Insurances")]
        public ActionResult GetInsurances()
        {
            return View("GetInsurances");
        }


        [ForMobile]
        public ActionResult GoInsurance()
        {

            // This demonstrates that you can custom ActionMethodSelectorAttribute
            // 

            return View();
        }


        
    }
}