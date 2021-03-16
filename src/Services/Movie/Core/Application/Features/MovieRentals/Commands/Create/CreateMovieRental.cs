using MediatR;
using System;
using TechnicalTest.Movie.Application.Responses;

namespace TechnicalTest.Movie.Application.Features.Movies.Commands.Create
{
    public class CreateMovieRental : IRequest<BaseResponse>
    {
        /// <example>10</example>
        public int MovieInventoryId { get; set; }
        public DateTime RentalBeginDateTime { get; set; }
        public DateTime RentalEndDateTime { get; set; }
        /// <example>10</example>
        public decimal RentalPrice { get; set; }
    }
}
