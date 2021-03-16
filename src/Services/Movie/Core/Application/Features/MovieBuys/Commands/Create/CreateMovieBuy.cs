using MediatR;
using System;
using TechnicalTest.Movie.Application.Responses;

namespace TechnicalTest.Movie.Application.Features.Movies.Commands.Create
{
    public class CreateMovieBuy : IRequest<BaseResponse>
    {
        /// <example>10</example>
        public int MovieInventoryId { get; set; }
        public DateTime BuyDateTime { get; set; }
        /// <example>100</example>
        public decimal BuyPrice { get; set; }
    }
}
