using System;
using System.Globalization;
using MVCPractices.Contracts.Services;

namespace MVCPractices.Services
{
    public class TestService : ITestService
    {

        public TestService()
        {
            
        }


        public string GetMessage()
        {
            return DateTime.Now.ToString(CultureInfo.InvariantCulture);
        }


        
    }
}