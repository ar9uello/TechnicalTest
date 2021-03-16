using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechnicalTest.Movie.Application.Features.Movies.Commands.Create;
using TechnicalTest.Movie.Application.Responses;

namespace TechnicalTest.Movie.Api.Controllers
{
    /// <summary>
    /// Users can buy a movie. 
    /// </summary>
    [Route("api/v1/movies")]
    [ApiController]
    public class MovieBuysController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovieBuysController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Users can buy a movie. 
        /// </summary>
        /// <response code="201">Buy created</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden Error - You don't have permission to access / on this server.</response>
        [Authorize]
        [HttpPost]
        [Route("buys")]
        public async Task<ActionResult<BaseResponse>> Create(CreateMovieBuy createMovieBuy)
        {
            return Created(nameof(Create), await _mediator.Send(createMovieBuy));
        }
    }
}
