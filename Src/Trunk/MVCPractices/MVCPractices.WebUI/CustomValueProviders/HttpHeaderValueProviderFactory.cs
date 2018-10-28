using System.Web.Mvc;

namespace MVCPractices.WebUI.CustomValueProviders
{
    public class HttpHeaderValueProviderFactory : ValueProviderFactory
    {
        public override IValueProvider GetValueProvider(ControllerContext controllerContext)
        {
            return new HttpHeaderValueProvider(controllerContext.HttpContext.Request.Headers);
            
        }
    }
}