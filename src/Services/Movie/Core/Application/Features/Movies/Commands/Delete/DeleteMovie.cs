using MediatR;
using TechnicalTest.Movie.Application.Responses;

namespace TechnicalTest.Movie.Application.Features.Movies.Commands.Delete
{
    public class DeleteMovie : IRequest<BaseResponse>
    {

        //Movie Id
        public int MovieId { get; set; }
        
    }
}
