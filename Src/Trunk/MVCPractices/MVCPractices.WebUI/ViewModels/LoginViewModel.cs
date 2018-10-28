using System.ComponentModel.DataAnnotations;

namespace MVCPractices.WebUI.ViewModels
{
    public class LoginViewModel
    {

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }


    }
}