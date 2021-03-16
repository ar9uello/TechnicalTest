using System;

namespace TechnicalTest.Movie.Application.Features.Movies.Queries
{
    public class GetUsersPenaltyListDto
    {
        public string UserEmail { get; set; }

        public DateTime RentalBeginDateTime { get; set; }
        public DateTime RentalEndDateTime { get; set; }
        public DateTime? ReturnDateTime { get; set; }
        public decimal RentalPrice { get; set; }
        
    }
}
