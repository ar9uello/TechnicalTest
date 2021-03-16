using System.Collections.Generic;
using System.Threading.Tasks;
using TechnicalTest.Movie.Domain.Entities;

namespace TechnicalTest.Movie.Application.Contracts.Persistence
{
    public interface IMovieInventoryRepository
    {
        Task<bool> IsStatusInventory(int movieInventoryId);
        Task<List<MovieInventory>> GetMovieLikes(int movieId);
    }
}
