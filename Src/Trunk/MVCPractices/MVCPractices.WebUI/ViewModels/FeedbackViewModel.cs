using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MVCPractices.WebUI.Helpers;

namespace MVCPractices.WebUI.ViewModels
{
    public class FeedbackViewModel : IValidatableObject
    {

        [Required]
        public string ReferralSource { get; set; }
        [Required]
        public string Comments { get; set; }

        public string OtherSource { get; set; }

        [Required]
        [HasToAgree(ErrorMessage = "You have to agree.")]
        public bool IsAgreed { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (ReferralSource.Contains("TV") && string.IsNullOrEmpty(OtherSource))
            {
                results.Add(new ValidationResult("You selected TV. Please describe more in Other Source."));
            }
            
            return results;

        }
    }
}