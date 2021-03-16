using MediatR;
using TechnicalTest.Movie.Application.Responses;

namespace TechnicalTest.Movie.Application.Features.Movies.Commands.Create
{
    public class CreateMovieLike : IRequest<BaseResponse>
    {
        /// <example>10</example>
        public int MovieId { get; set; }        
    }
}
