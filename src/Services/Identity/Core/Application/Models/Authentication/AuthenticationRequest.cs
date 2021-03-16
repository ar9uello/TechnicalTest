
namespace TechnicalTest.Identity.Application.Models.Authentication
{
    public class AuthenticationRequest
    {
        /// <example>admin</example>
        public string UserName { get; set; }
        /// <example>Applaudo&amp;01!</example>
        public string Password { get; set; }
    }
}
