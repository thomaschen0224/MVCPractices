using System.Web.Mvc;
using Newtonsoft.Json;

namespace MVCPractices.WebUI.CustomActionResultHelpers
{
    public class CustomJsonResult : ActionResult
    {
        private readonly object _data;

        public CustomJsonResult(object data)
        {
            _data = data;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            
            var json = JsonConvert.SerializeObject(_data);
            var respones = context.HttpContext.Response;
            respones.ContentType = "application/json";
            respones.Write(json);
            

        }
    }
}