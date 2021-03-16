using System.Threading.Tasks;
using TechnicalTest.Identity.Application.Models.Authentication;

namespace TechnicalTest.Identity.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
    }
}
