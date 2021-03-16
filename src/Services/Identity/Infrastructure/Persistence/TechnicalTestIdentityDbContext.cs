using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TechnicalTest.Identity.Persistence.Models;

namespace TechnicalTest.Identity.Persistence
{
    public class TechnicalTestIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public TechnicalTestIdentityDbContext(DbContextOptions<TechnicalTestIdentityDbContext> options) : base(options)
        {
        }
    }
}
