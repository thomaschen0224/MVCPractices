using System.ComponentModel.DataAnnotations;

namespace MVCPractices.WebUI.Helpers
{
    public class HasToAgree: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var agreed = value is bool b && b;
            return agreed;
        }
    }
}