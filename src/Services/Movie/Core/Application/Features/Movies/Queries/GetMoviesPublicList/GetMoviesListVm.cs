using System.Collections.Generic;
using TechnicalTest.Movie.Application.Responses;

namespace TechnicalTest.Movie.Application.Features.Movies.Queries
{
    public class GetMoviesListVm : BasePagingResponse
    {
        public ICollection<GetMoviesListDto> Data { get; set; }
    }
}
