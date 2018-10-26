using MVCPractices.Contracts.Repositories;
using MVCPractices.Models;

namespace MVCPractices.Repositories
{
    public class UserRepository : IUserRepository
    {

        public UserRepository()
        {
            
        }



        public virtual CurrentUser GetCurrentUser(string guid)
        {
            return new CurrentUser();
        }



        
    }
}