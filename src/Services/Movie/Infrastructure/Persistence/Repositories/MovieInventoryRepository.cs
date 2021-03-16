using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalTest.Movie.Application.Contracts.Persistence;
using TechnicalTest.Movie.Domain.Entities;
using TechnicalTest.Movie.Persistence.Repositories.Base;

namespace TechnicalTest.Movie.Persistence.Repositories
{
    public class MovieInventoryRepository : BaseRepository<MovieInventory>, IMovieInventoryRepository
    {
        public MovieInventoryRepository(TechnicalTestDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<bool> IsStatusInventory(int movieInventoryId)
        {
            return (await GetInventoryStatus(movieInventoryId) == Domain.Enums.MovieInventoryStatus.Inventory);
        }

        private async Task<Domain.Enums.MovieInventoryStatus> GetInventoryStatus(int id)
        {
            return (Domain.Enums.MovieInventoryStatus)((await _dbContext.MovieInventories.FindAsync(id)).MovieInventoryStatusId);
        }

        public async Task<List<MovieInventory>> GetMovieLikes(int movieId)
        {
            return await _dbContext.MovieInventories.Where(x => x.MovieId == movieId).ToListAsync();
        }
    }
}
