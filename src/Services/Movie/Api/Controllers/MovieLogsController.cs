using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechnicalTest.Movie.Application.Features.Movies.Queries;

namespace TechnicalTest.Movie.Api.Controllers
{
    /// <summary>
    /// Keep a log of all rentals and purchases (who, how many, when). [Only admin users]
    /// </summary>
    public class MovieLogsController : Controller
    {
        private readonly IMediator _mediator;

        public MovieLogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Keep a log of all rentals and purchases (who, how many, when). [Only admin users]
        /// </summary>
        /// <param name="movieId" example="1"></param>
        /// <response code="200">Log purchases and buy by movie.</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden Error - You don't have permission to access / on this server.</response>
        [Authorize]
        [HttpGet]
        [Route("api/v1/movies/{movieId}/logs")]
        public async Task<ActionResult<List<GetMoviesAdminListVm>>> GetLogList(int movieId)
        {
            var dtos = await _mediator.Send(new GetLogAdminList() { MovieId = movieId });
            return Ok(dtos);
        }

    }
}
