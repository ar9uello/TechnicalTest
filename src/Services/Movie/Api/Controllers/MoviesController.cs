using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechnicalTest.Movie.Application.Features.Movies.Queries;

namespace TechnicalTest.Movie.Api.Controllers
{
    /// <summary>
    /// List of available movies (authenticated or not)
    /// </summary>
    [Route("api/v1/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// List of available movies (authenticated or not)
        /// </summary>
        /// <param name="page" example="1"></param>
        /// <param name="size" example="10"></param>
        /// <param name="sort" example="-likes,-stock,title"></param>
        /// <param name="search" example="the"></param>
        /// <response code="200">See all available movies.</response>
        [HttpGet]
        public async Task<ActionResult<List<GetMoviesListVm>>> GetList(int page = 1, int size = 10, string sort = "", string search = "")
        {
            var dtos = await _mediator.Send(new GetMoviesList() { Page = page, Size = size, Sort = sort, Search = search });
            return Ok(dtos);
        }

    }
}
