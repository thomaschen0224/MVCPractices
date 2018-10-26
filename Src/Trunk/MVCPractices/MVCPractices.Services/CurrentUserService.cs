using MVCPractices.Contracts.Repositories;
using MVCPractices.Contracts.Services;
using MVCPractices.Models;

namespace MVCPractices.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IUserRepository _userRepository;

        public CurrentUserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public CurrentUser GetCurrentUser(string guid)
        {
            return _userRepository.GetCurrentUser(guid);
        }
        

        
    }
}