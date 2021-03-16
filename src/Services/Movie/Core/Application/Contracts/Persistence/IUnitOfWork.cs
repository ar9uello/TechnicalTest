
namespace TechnicalTest.Movie.Application.Contracts.Persistence
{
    public interface IUnitOfWork
    {
        IMovieBuyRepository MovieBuyRepository { get; }
        IMovieInventoryRepository MovieInventoryRepository { get; }
        IMovieLikeRepository MovieLikeRepository { get; }
        IMovieRentalRepository MovieRentalRepository { get; }
        IMovieRepository MovieRepository { get; }
    }
}
