using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using TechnicalTest.Identity.Persistence.Models;

namespace TechnicalTest.Identity.Persistence.Seed
{
    public static class UserCreator
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, Role role, string user)
        {
            user = user.ToLower();
            var applicationUser = new ApplicationUser
            {
                FirstName = (string.IsNullOrEmpty(user) ? string.Empty : user.First().ToString().ToUpper() + string.Join("", user.Skip(1))),
                LastName = "TechnicalTest",
                UserName = user,
                Email = $"{user}@email.com",
                EmailConfirmed = true
            };
            var auser = await userManager.FindByEmailAsync(applicationUser.Email);
            if (auser == null)
            {
                await userManager.CreateAsync(applicationUser, "Applaudo&01!");
                auser = await userManager.FindByEmailAsync(applicationUser.Email);
            }

            var identityRole = new IdentityRole
            {
                Name = Enum.GetName(typeof(Role), role),
                NormalizedName = Enum.GetName(typeof(Role), role).ToUpper()
            };
            var irole = await roleManager.FindByNameAsync(identityRole.Name);
            if (irole == null)
            {
                await roleManager.CreateAsync(identityRole);
                irole = await roleManager.FindByNameAsync(identityRole.Name);
            }
            await userManager.AddToRoleAsync(auser, irole.Name);
        }
    }
}
