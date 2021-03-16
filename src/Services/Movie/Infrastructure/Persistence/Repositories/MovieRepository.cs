using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using TechnicalTest.Movie.Application.Contracts.Persistence;
using TechnicalTest.Movie.Persistence.Repositories.Base;

namespace TechnicalTest.Movie.Persistence.Repositories
{

    public class MovieRepository : BaseRepository<Domain.Entities.Movie>, IMovieRepository
    {
        public MovieRepository(TechnicalTestDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Domain.Entities.Movie>> GetPagedMovies(int page, int size, string sort, string search, bool? availability)
        {
            sort = (string.IsNullOrEmpty(sort) ? "Title" : sort);

            sort.Split(',').ToList().ForEach(x => x = (x.Contains("-") ? $"{x.Substring(1, x.Length - 1)} DESC" : sort));

            var list = new List<Domain.Entities.Movie>();
            if (string.IsNullOrEmpty(search))
            {
                list = await _dbContext.Movies
                    .Where(x => (availability == null || (availability != null && x.Availability == availability.GetValueOrDefault(true))))
                    .OrderBy(sort).Skip((page - 1) * size).Take(size).AsNoTracking()
                    .ToListAsync();
            }
            else
            {
                list = await _dbContext.Movies
                    .Where(x => (availability == null || (availability != null && x.Availability == availability.GetValueOrDefault(true))) && (x.Title.Contains(search) || x.Description.Contains(search)))
                    .OrderBy(sort).Skip((page - 1) * size).Take(size).AsNoTracking()
                    .ToListAsync();
            }

            return list;
        }

        public async Task<int> GetTotalCountOfMovies(string search, bool? availability)
        {
            if (string.IsNullOrEmpty(search)) return await _dbContext.Movies.CountAsync(x => x.Availability == availability);
            else return await _dbContext.Movies.CountAsync(x => x.Availability == availability && x.Title.Contains(search) && x.Description.Contains(search));
        }

    }
}
