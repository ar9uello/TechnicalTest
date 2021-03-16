using TechnicalTest.Movie.Application.Responses;

namespace TechnicalTest.Movie.Application.Features.Movies.Commands.Create
{
    public class CreateMovieResponse : BaseResponse
    {
        public CreateMovieResponse() : base() {

        }

        public CreateMovieResponseDto Data { get; set; }
        
    }
}
