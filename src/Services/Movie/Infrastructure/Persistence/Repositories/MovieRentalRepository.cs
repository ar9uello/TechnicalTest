using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalTest.Movie.Application.Contracts.Persistence;
using TechnicalTest.Movie.Domain.Entities;
using TechnicalTest.Movie.Persistence.Repositories.Base;

namespace TechnicalTest.Movie.Persistence.Repositories
{

    public class MovieRentalRepository : BaseRepository<MovieRental>, IMovieRentalRepository
    {
        public MovieRentalRepository(TechnicalTestDbContext dbContext) : base(dbContext)
        {

        }

        public async Task CreateMovieRental(MovieRental MovieRental)
        {
            //Change to Rental Status
            var movieInventory = await _dbContext.MovieInventories.FindAsync(MovieRental.MovieInventoryId);
            movieInventory.MovieInventoryStatusId = (int)Domain.Enums.MovieInventoryStatus.Rent;

            //Remove one from stock 
            var movie = await _dbContext.Movies.FindAsync(movieInventory.MovieId);
            movie.Stock = (await GetStock(movie.Id)) - 1;

            //Save
            await _dbContext.MovieRentals.AddAsync(MovieRental);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<MovieRental>> GetMovieRentals(int movieId)
        {
            var list = await _dbContext.MovieInventories.Where(x => x.MovieId == movieId).Select(x => x.Id).ToListAsync();
            return await _dbContext.MovieRentals.Where(x => list.Contains(x.MovieInventoryId)).ToListAsync();
        }

        public async Task<List<MovieRental>> GetUsersPenalty()
        {
            return await _dbContext.MovieRentals.Where(x => x.RentalEndDateTime < DateTime.Now && x.ReturnDateTime == null).ToListAsync();
        }

    }
}
