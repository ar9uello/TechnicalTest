using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechnicalTest.Movie.Application.Features.Movies.Commands.Create;
using TechnicalTest.Movie.Application.Responses;

namespace TechnicalTest.Movie.Api.Controllers
{
    /// <summary>
    /// Users can like movies.
    /// </summary>
    [Route("api/v1/movies")]
    [ApiController]
    public class MovieLikesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovieLikesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Users can like movies.
        /// </summary>
        /// <response code="201">Movie Like created</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden Error - You don't have permission to access / on this server.</response>
        [Authorize]
        [HttpPost]
        [Route("{movieId}/likes")]
        public async Task<ActionResult<BaseResponse>> Create(int movieId)
        {
            return Created(nameof(Create), await _mediator.Send(new CreateMovieLike { MovieId = movieId }));
        }
    }
}
