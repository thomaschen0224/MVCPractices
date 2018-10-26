using MVCPractices.Models;

namespace MVCPractices.Contracts.Repositories
{
    public interface IUserRepository
    {
        CurrentUser GetCurrentUser(string guid);
    }
}