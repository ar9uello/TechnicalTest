using Microsoft.Extensions.DependencyInjection;
using TechnicalTest.Identity.Application.Contracts.Identity;

namespace TechnicalTest.Identity.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<IIdentityService, IdentityService>();
            return services;
        }
    }
}
