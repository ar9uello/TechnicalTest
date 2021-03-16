using MediatR;

namespace TechnicalTest.Movie.Application.Features.Movies.Queries
{
    public class GetMoviesList : IRequest<GetMoviesListVm>
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public string Sort { get; set; }
        public string Search { get; set; }
    }
}
