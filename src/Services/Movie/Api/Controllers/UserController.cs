using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechnicalTest.Movie.Application.Features.Users.Queries.GetUsersPenaltyList;

namespace TechnicalTest.Movie.Api.Controllers
{
    /// <summary>
    /// For renting functionality you must keep track when the user has to return the movie and apply a monetary penalty if there is a delay.
    /// </summary>
    [Route("api/v1/users")]
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// For renting functionality you must keep track when the user has to return the movie and apply a monetary penalty if there is a delay.
        /// </summary>
        /// <response code="200">Log purchases and buy by movie.</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden Error - You don't have permission to access / on this server.</response>
        [Authorize]
        [HttpGet]
        [Route("penalty")]
        public async Task<ActionResult<List<GetUsersPenaltyListVm>>> GetList()
        {
            var dtos = await _mediator.Send(new GetUsersPenaltyList());
            return Ok(dtos);
        }

    }
}
