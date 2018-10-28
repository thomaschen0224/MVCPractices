using System;
using System.IO;
using System.Web.Mvc;
using System.Xml;
using System.Xml.XPath;
using MVCPractices.SharedKernel;
using MVCPractices.WebUI.Models;
using NLog;

namespace MVCPractices.WebUI.CustomModelBinders
{
    public class XMLModelBinder : IModelBinder
    {

        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {

            try
            {

                if (bindingContext.ModelType == typeof(PatientModel))
                {

                    var inputStream = controllerContext.HttpContext.Request.InputStream;
                    using (var sr = new StreamReader(inputStream))
                    {
                        var data = sr.ReadToEnd();
                        return GetPatientModel(data);
                    }
                    
                }

            }
            catch (Exception e)
            {
                _logger.Error(e);
            }

            return null;


        }

        private PatientModel GetPatientModel(string xml)
        {

            var model = new PatientModel();
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);

            XPathNavigator main = xmlDoc.CreateNavigator();
            XPathNavigator node = main.SelectSingleNode(".//Patient");

            model.PatientId = node.GetAttribute("patientId", "").ToInt();
            model.FirstName = node.GetAttribute("firstName", "");
            model.LastName = node.GetAttribute("lastName", "");
            model.Gender = node.GetAttribute("gender", "");

            return model;
            
        }


    }
}