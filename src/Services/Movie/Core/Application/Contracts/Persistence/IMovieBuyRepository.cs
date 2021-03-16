using System.Collections.Generic;
using System.Threading.Tasks;
using TechnicalTest.Movie.Application.Contracts.Persistence.Base;
using TechnicalTest.Movie.Domain.Entities;

namespace TechnicalTest.Movie.Application.Contracts.Persistence
{
    public interface IMovieBuyRepository : IAsyncRepository<MovieBuy>
    {
        Task CreateMovieBuy(MovieBuy MovieBuy);
        Task<List<MovieBuy>> GetMovieBuys(int movieId);
    }
}
