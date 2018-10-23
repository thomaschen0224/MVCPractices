using System.Web.Mvc;
using MVCPractices.WebUI.ViewModels;

namespace MVCPractices.WebUI.Controllers
{
    public class FeedbackController : Controller
    {



        public ActionResult NewFeedback()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewFeedback(FeedbackViewModel model)
        {

            if (ModelState.IsValid)
            {
                var comments = model.Comments;
            }

            return View();
        }


        
    }
}