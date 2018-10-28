using MVCPractices.SharedKernel.Enums;

namespace MVCPractices.Models
{
    public class CurrentUser
    {

        public int HighestCompleted { get; set; }

        public bool IsAuthorized { get; set; }
        public AuthorizedRoles AuthorizedRoles { get; set; }




    }
}