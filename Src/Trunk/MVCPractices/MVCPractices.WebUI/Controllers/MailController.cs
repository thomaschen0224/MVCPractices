using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCPractices.WebUI.Infrastructure;

namespace MVCPractices.WebUI.Controllers
{
    [WorkflowFilter(MinmunWorkflow = 20, CurrentWorkflow = 30)]
    public class MailController : Controller
    {


        public ActionResult NewMail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveMail()
        {
            return RedirectToAction("Index", "Home");
        }



    }
}