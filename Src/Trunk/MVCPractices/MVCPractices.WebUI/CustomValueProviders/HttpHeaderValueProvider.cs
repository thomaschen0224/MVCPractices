using System;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace MVCPractices.WebUI.CustomValueProviders
{
    public class HttpHeaderValueProvider : IValueProvider
    {
        private readonly NameValueCollection _headers;
        private readonly string[] _headerKeys;

        public HttpHeaderValueProvider(NameValueCollection headers)
        {
            _headers = headers;
            _headerKeys = headers.AllKeys;
        }

        public bool ContainsPrefix(string prefix)
        {
            var success = _headerKeys.Any(k => k.Replace("-", "").Equals(prefix, StringComparison.OrdinalIgnoreCase));
            return success;

        }

        public ValueProviderResult GetValue(string key)
        {

            var headerKey =
                _headerKeys.FirstOrDefault(k => k.Replace("-", "").Equals(key, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(headerKey))
            {
                var value = _headers[headerKey];
                return new ValueProviderResult(value, value, CultureInfo.CurrentCulture);
            }

            return null;


        }


    }
}