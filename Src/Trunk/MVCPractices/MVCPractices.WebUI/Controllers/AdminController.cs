using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCPractices.SharedKernel.Enums;
using MVCPractices.WebUI.CustomAuthentication;

namespace MVCPractices.WebUI.Controllers
{
    [BasicAuthen]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }


        [AuthorizedRole(AuthorizedRoles = AuthorizedRoles.Administrator )]
        public ActionResult Edit()
        {
            return View();
        }
        


    }
}