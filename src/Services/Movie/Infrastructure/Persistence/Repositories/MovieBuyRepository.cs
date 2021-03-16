using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalTest.Movie.Application.Contracts.Persistence;
using TechnicalTest.Movie.Domain.Entities;
using TechnicalTest.Movie.Persistence.Repositories.Base;

namespace TechnicalTest.Movie.Persistence.Repositories
{

    public class MovieBuyRepository : BaseRepository<MovieBuy>, IMovieBuyRepository
    {
        public MovieBuyRepository(TechnicalTestDbContext dbContext) : base(dbContext)
        {

        }

        public async Task CreateMovieBuy(MovieBuy MovieBuy)
        {
            //Change to Buy Status
            var movieInventory = await _dbContext.MovieInventories.FindAsync(MovieBuy.MovieInventoryId);
            movieInventory.MovieInventoryStatusId = (int)Domain.Enums.MovieInventoryStatus.Buy;

            //Remove one from stock 
            var movie = await _dbContext.Movies.FindAsync(movieInventory.MovieId);
            movie.Stock = (await GetStock(movie.Id)) - 1;

            //Save
            await _dbContext.MovieBuys.AddAsync(MovieBuy);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<MovieBuy>> GetMovieBuys(int movieId)
        {
            var list = await _dbContext.MovieInventories.Where(x => x.MovieId == movieId).Select(x => x.Id).ToListAsync();
            return await _dbContext.MovieBuys.Where(x => list.Contains(x.MovieInventoryId)).ToListAsync();
        }
    }
}
