using System.Collections.Generic;
using System.Threading.Tasks;
using TechnicalTest.Movie.Application.Contracts.Persistence.Base;

namespace TechnicalTest.Movie.Application.Contracts.Persistence
{
    public interface IMovieRepository : IAsyncRepository<Domain.Entities.Movie>
    {
        Task<List<Domain.Entities.Movie>> GetPagedMovies(int page, int size, string sort, string search, bool? availability);
        Task<int> GetTotalCountOfMovies(string search, bool? availability);
    }
}
