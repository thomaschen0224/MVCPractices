using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCPractices.WebUI.CustomActionResultHelpers;
using MVCPractices.WebUI.Models;

namespace MVCPractices.WebUI.Controllers
{
    public class PatientController : BaseController
    {


        public ActionResult GetHttpHeaders(HttpHeaderData data)
        {

            // This is an example to demonstrate IValueProvider and ValueProviderFactory
            // You may create your own way how to map Model.
            // When MVC can find a correct ValueProviderFactory, it will not go next factory.

            // ValueProvider provides how data is bind with default model binding.


            var userAgent = data.UserAgent;

            return View();
        }


        [HttpPost]
        public ActionResult AddPatient(PatientModel model)
        {

            // This is an example to demonstrate IModelBinder and IModelBinderProvider
            // Check folder: CustomModelBinders
            // ModelBinderProvider will need to be registered at Global


            var patientId = model.PatientId;


            return new EmptyResult();


        }



        public ActionResult GetPatientData()
        {

            // This is an example to demonstrate that you can custom ActionResult
            // You may have fixed logic to return Response. 
            // You can create custom ActionResult to reuse the codes.

            var patient = new PatientModel();
            patient.FirstName = "Thomas";
            patient.Gender = "Male";
            patient.LastName = "Chen";
            patient.PatientId = 1234;

            return CustomJsonResult(patient);


        }




    }
}