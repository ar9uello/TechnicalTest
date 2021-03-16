using TechnicalTest.Movie.Application.Responses;

namespace TechnicalTest.Movie.Application.Features.Movies.Commands.Update
{
    public class UpdateMovieResponse : BaseResponse
    {
        public UpdateMovie Data { get; set; }
    }
}
