using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCPractices.Models;
using MVCPractices.SharedKernel.Enums;
using MVCPractices.WebUI.ViewModels;

namespace MVCPractices.WebUI.Controllers
{
    public class LoginController : Controller
    {


        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Verify(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {
                if (model.UserName.Equals("test") && model.Password.Equals("1234"))
                {
                    Session["AuthorizedUser"] = new CurrentUser()
                        {IsAuthorized = true, AuthorizedRoles = AuthorizedRoles.Administrator};
                    return RedirectToAction("Index", "Admin");
                }
                else if (model.UserName.Equals("test2") && model.Password.Equals("1234"))
                {
                    Session["AuthorizedUser"] = new CurrentUser()
                        { IsAuthorized = true, AuthorizedRoles = AuthorizedRoles.Moderator };
                    return RedirectToAction("Index", "Admin");

                }
                else
                {
                    return View("Index");
                }

            }
            else
            {
                return View("Index");
            }
            
        }



        



        
    }
}