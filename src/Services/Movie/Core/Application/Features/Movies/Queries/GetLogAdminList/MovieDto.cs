using System;

namespace TechnicalTest.Movie.Application.Features.Movies.Queries
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public int Likes { get; set; }
        public decimal RentalPrice { get; set; }
        public decimal BuyPrice { get; set; }
        public bool Availability { get; set; }
        public string UserEmail { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
