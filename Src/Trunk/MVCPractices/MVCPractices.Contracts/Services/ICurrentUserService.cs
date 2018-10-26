using MVCPractices.Models;

namespace MVCPractices.Contracts.Services
{
    public interface ICurrentUserService
    {
        CurrentUser GetCurrentUser(string guid);
    }
}