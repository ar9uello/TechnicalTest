using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechnicalTest.Movie.Application.Features.Movies.Commands.Create;
using TechnicalTest.Movie.Application.Features.Movies.Commands.Delete;
using TechnicalTest.Movie.Application.Features.Movies.Commands.Update;
using TechnicalTest.Movie.Application.Features.Movies.Queries;

namespace TechnicalTest.Movie.Api.Controllers
{
    /// <summary>
    /// Add Modify and Delete a movie. [Only admin users]
    /// [Only admin users]
    /// </summary>
    [Route("api/v1/movies")]
    public class MoviesAdminController : Controller
    {
        private readonly IMediator _mediator;

        public MoviesAdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Add a Movie - Only users with admin role are allowed to perform the action
        /// </summary>
        /// <response code="201">Movie created</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden Error - You don't have permission to access / on this server.</response>
        [Authorize]
        [HttpPost]
        [Route("admin")]
        public async Task<ActionResult<CreateMovieResponse>> Create([FromBody] CreateMovie createMovie)
        {
            return Created(nameof(Create), await _mediator.Send(createMovie));
        }

        /// <summary>
        /// Modify a movie - Only users with admin role are allowed to perform the action
        /// </summary>
        /// <response code="200">Movie updated</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden Error - You don't have permission to access / on this server.</response>
        [Authorize]
        [HttpPut]
        [Route("admin")]
        public async Task<ActionResult<UpdateMovieResponse>> Update([FromBody] UpdateMovie updateMovie)
        {
            return Ok(await _mediator.Send(updateMovie));
        }

        /// <summary>
        /// Delete a movie - Only users with admin role are allowed to perform the action
        /// </summary>
        /// <response code="200">Movie deleted</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden Error - You don't have permission to access / on this server.</response>
        [Authorize]
        [HttpDelete]
        [Route("admin/{movieId}")]
        public async Task<ActionResult> Delete(int movieId)
        {
            var deleteEventCommand = new DeleteMovie() { MovieId = movieId };
            return Ok(await _mediator.Send(deleteEventCommand));
        }

        /// <summary>
        /// Modify Availability - Only users with admin role are allowed to perform the action
        /// </summary>
        /// <response code="200">Movie updated</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden Error - You don't have permission to access / on this server.</response>
        [Authorize]
        [HttpPatch]
        [Route("admin")]
        public async Task<ActionResult<UpdateMovieAvailabilityResponse>> Update([FromBody] UpdateMovieAvailability updateMovieAvailability)
        {
            return Ok(await _mediator.Send(updateMovieAvailability));
        }

        /// <summary>
        /// See all movies filtering [Only admin users]
        /// </summary>
        /// <remarks>
        /// As an admin I’m able to see all movies and filtering by availability/unavailability.<br />
        /// Search through the movies by name.<br />
        /// [You can sort by any existing column, use '-' as a descent indicator. You can also add multiple columns separated by commas. Example: -likes,-stock,title]<br />
        /// The list must have pagination functionality.<br />
        /// </remarks>
        /// <param name="page" example="1"></param>
        /// <param name="size" example="10"></param>
        /// <param name="sort" example="-likes,-stock,title"></param>
        /// <param name="search" example="the"></param>
        /// <param name="availability" example="true"></param>
        /// <response code="200">See all movies filtering [Only admin]</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden Error - You don't have permission to access / on this server.</response>
        [Authorize]
        [HttpGet]
        [Route("admin")]
        public async Task<ActionResult<List<GetMoviesAdminListVm>>> GetList(int page = 1, int size = 10, string sort = "", string search = "", bool? availability = null)
        {
            var dtos = await _mediator.Send(new GetMoviesAdminList() { Page = page, Size = size, Sort = sort, Search = search, Availability = availability });
            return Ok(dtos);
        }

    }
}
