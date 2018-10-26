using System.Web;
using System.Web.Mvc;
using MVCPractices.WebUI.Infrastructure;

namespace MVCPractices.WebUI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new GlobalExceptionFilter());
            //filters.Add(new HandleErrorAttribute());

        }
    }
}
