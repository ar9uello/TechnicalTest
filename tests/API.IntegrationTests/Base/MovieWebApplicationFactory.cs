using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using TechnicalTest.Movie.Api;

namespace API.IntegrationTests
{
 
    public class MovieWebApplicationFactory : WebApplicationFactory<Startup> 
    {
        public MovieWebApplicationFactory() { }

        protected override void ConfigureWebHost(IWebHostBuilder builder) { }
    }
}
