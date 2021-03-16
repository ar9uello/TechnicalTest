using System.Collections.Generic;
using System.Threading.Tasks;
using TechnicalTest.Movie.Application.Contracts.Persistence.Base;
using TechnicalTest.Movie.Domain.Entities;

namespace TechnicalTest.Movie.Application.Contracts.Persistence
{
    public interface IMovieRentalRepository : IAsyncRepository<MovieRental>
    {
        Task CreateMovieRental(MovieRental MovieRental);
        Task<List<MovieRental>> GetMovieRentals(int movieId);
        Task<List<MovieRental>> GetUsersPenalty();
    }
}
