using Domain.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Threading.Tasks;
using TechnicalTest.Identity.Persistence.Models;
using TechnicalTest.Identity.Persistence.Seed;

namespace TechnicalTest.Identity.Api
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            var host = CreateHostBuilder(args).Build();

            //using (var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;

            //    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            //    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            //    await UserCreator.SeedAsync(userManager, roleManager, Role.Administrator, "admin");
            //    await UserCreator.SeedAsync(userManager, roleManager, Role.User, "user");

            //    await UserCreator.SeedAsync(userManager, roleManager, Role.User, "user1");
            //    await UserCreator.SeedAsync(userManager, roleManager, Role.User, "user2");
            //    await UserCreator.SeedAsync(userManager, roleManager, Role.User, "user3");
            //    await UserCreator.SeedAsync(userManager, roleManager, Role.User, "user4");
            //    await UserCreator.SeedAsync(userManager, roleManager, Role.User, "user5");

            //    Log.Information("Application Starting");
            //}

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
