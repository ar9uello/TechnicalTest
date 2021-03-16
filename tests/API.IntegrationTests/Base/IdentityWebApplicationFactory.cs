using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using TechnicalTest.Identity.Api;

namespace API.IntegrationTests
{
 
    public class IdentityWebApplicationFactory : WebApplicationFactory<Startup> 
    {
        public IdentityWebApplicationFactory() { }

        protected override void ConfigureWebHost(IWebHostBuilder builder) { }
    }
}
