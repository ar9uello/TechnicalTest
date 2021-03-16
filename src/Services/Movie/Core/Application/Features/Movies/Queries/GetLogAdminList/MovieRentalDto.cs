using System;

namespace TechnicalTest.Movie.Application.Features.Movies.Queries
{
    public class MovieRentalDto
    {
        public int Id { get; set; }
        public int MovieInventoryId { get; set; }
        public DateTime RentalBeginDateTime { get; set; }
        public DateTime RentalEndDateTime { get; set; }
        public DateTime? ReturnDateTime { get; set; }
        public decimal RentalPrice { get; set; }
        public string UserEmail { get; set; }
        public DateTime EntryDate { get; set; }

    }
}
