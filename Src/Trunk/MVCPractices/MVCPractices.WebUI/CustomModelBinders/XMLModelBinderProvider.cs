using System;
using System.Web.Mvc;
using MVCPractices.WebUI.Models;

namespace MVCPractices.WebUI.CustomModelBinders
{
    public class XMLModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(Type modelType)
        {
            if (modelType == typeof(PatientModel))
            {
                return new XMLModelBinder();
            }

            return null;

        }
    }
}