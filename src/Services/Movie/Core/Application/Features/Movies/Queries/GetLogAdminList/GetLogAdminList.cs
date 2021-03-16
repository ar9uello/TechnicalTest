using MediatR;

namespace TechnicalTest.Movie.Application.Features.Movies.Queries
{
    public class GetLogAdminList : IRequest<GetLogAdminListResponse>
    {
        //Movie Id
        public int MovieId { get; set; }
    }
}
