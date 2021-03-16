using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechnicalTest.Movie.Application.Features.Movies.Commands.Create;
using TechnicalTest.Movie.Application.Responses;

namespace TechnicalTest.Movie.Api.Controllers
{
    /// <summary>
    /// Users can rent a movie. 
    /// </summary>
    [Route("api/v1/movies")]
    [ApiController]
    public class MovieRentalsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovieRentalsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Users can rent a movie. Notice that the MovieId is not in the URL because the required Id is from the Inventory table. 
        /// </summary>
        /// <response code="201">Rent created</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden Error - You don't have permission to access / on this server.</response>
        [Authorize]
        [HttpPost]
        [Route("rentals")]
        public async Task<ActionResult<BaseResponse>> Create(CreateMovieRental createMovieRental)
        {
            return Created(nameof(Create), await _mediator.Send(createMovieRental));
        }
    }
}
