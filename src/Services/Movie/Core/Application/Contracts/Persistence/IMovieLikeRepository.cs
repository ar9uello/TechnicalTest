using System.Collections.Generic;
using System.Threading.Tasks;
using TechnicalTest.Movie.Application.Contracts.Persistence.Base;
using TechnicalTest.Movie.Domain.Entities;

namespace TechnicalTest.Movie.Application.Contracts.Persistence
{
    public interface IMovieLikeRepository : IAsyncRepository<MovieLike>
    {
        Task CreateMovieLike(MovieLike movieLike);
        Task<bool> IsMovieLikeUnique(MovieLike movieLike);
        Task<List<MovieLike>> GetMovieLikes(int movieId);
    }
}
