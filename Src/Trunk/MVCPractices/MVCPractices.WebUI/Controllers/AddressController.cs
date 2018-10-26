using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCPractices.WebUI.Infrastructure;

namespace MVCPractices.WebUI.Controllers
{
    [WorkflowFilter(MinmunWorkflow = 10, CurrentWorkflow = 20)]
    public class AddressController : Controller
    {
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveAddress(string data)
        {
            return RedirectToAction("NewMail", "Mail");
        }
    }
}