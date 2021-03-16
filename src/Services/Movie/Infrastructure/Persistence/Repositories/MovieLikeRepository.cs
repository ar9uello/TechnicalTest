using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalTest.Movie.Application.Contracts.Persistence;
using TechnicalTest.Movie.Domain.Entities;
using TechnicalTest.Movie.Persistence.Repositories.Base;

namespace TechnicalTest.Movie.Persistence.Repositories
{

    public class MovieLikeRepository : BaseRepository<MovieLike>, IMovieLikeRepository
    {
        public MovieLikeRepository(TechnicalTestDbContext dbContext) : base(dbContext)
        {

        }

        public async Task CreateMovieLike(MovieLike movieLike)
        {
            var movie = await _dbContext.Movies.FindAsync(movieLike.MovieId);
            movie.Likes = (await GetLikes(movie.Id)) + 1;

            await _dbContext.MovieLikes.AddAsync(movieLike);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> IsMovieLikeUnique(MovieLike movieLike)
        {
            return !await _dbContext.MovieLikes.AnyAsync(x => x.MovieId == movieLike.MovieId && x.UserEmail == movieLike.UserEmail);
        }

        public async Task<List<MovieLike>> GetMovieLikes(int movieId)
        {
            return await _dbContext.MovieLikes.Where(x => x.MovieId == movieId).ToListAsync();
        }
    }
}
