using TechnicalTest.Movie.Application.Contracts.Persistence;

namespace TechnicalTest.Movie.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TechnicalTestDbContext _dbContext;
        private readonly IMovieBuyRepository _movieBuyRepository;
        private readonly IMovieInventoryRepository _movieInventoryRepository;
        private readonly IMovieLikeRepository _movieLikeRepository;
        private readonly IMovieRentalRepository _movieRentalRepository;
        private readonly IMovieRepository _movieRepository;
        
        public UnitOfWork(TechnicalTestDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public IMovieBuyRepository MovieBuyRepository => _movieBuyRepository ?? new MovieBuyRepository(_dbContext);
        public IMovieInventoryRepository MovieInventoryRepository => _movieInventoryRepository ?? new MovieInventoryRepository(_dbContext);
        public IMovieLikeRepository MovieLikeRepository => _movieLikeRepository ?? new MovieLikeRepository(_dbContext);
        public IMovieRentalRepository MovieRentalRepository => _movieRentalRepository ?? new MovieRentalRepository(_dbContext);
        public IMovieRepository MovieRepository => _movieRepository ?? new MovieRepository(_dbContext);

    }

}
