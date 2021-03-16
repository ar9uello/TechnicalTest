
namespace TechnicalTest.Movie.Application.Contracts.Identity
{
    public interface IIdentityService
    {
        string GetUserEmail();
        bool IsUserAdmin();
        bool IsUserRole();
    }
}
