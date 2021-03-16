using Microsoft.EntityFrameworkCore;
using TechnicalTest.Movie.Domain.Entities;

namespace TechnicalTest.Movie.Persistence
{
    public class TechnicalTestDbContext : DbContext
    {
        public TechnicalTestDbContext(DbContextOptions<TechnicalTestDbContext> options)
           : base(options)
        {
        }

        public DbSet<Domain.Entities.Movie> Movies { get; set; }
        public DbSet<MovieBuy> MovieBuys { get; set; }
        public DbSet<MovieInventory> MovieInventories { get; set; }
        public DbSet<MovieInventoryStatus> MovieInventoryStatuses { get; set; }
        public DbSet<MovieLike> MovieLikes { get; set; }
        public DbSet<MovieRental> MovieRentals { get; set; }

    }
}
