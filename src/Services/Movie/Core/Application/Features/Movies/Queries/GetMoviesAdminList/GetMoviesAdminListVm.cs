using System.Collections.Generic;
using TechnicalTest.Movie.Application.Responses;

namespace TechnicalTest.Movie.Application.Features.Movies.Queries
{
    public class GetMoviesAdminListVm : BasePagingResponse
    {
        public ICollection<GetMoviesAdminListDto> Data { get; set; }
    }
}
