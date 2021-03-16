using System;

namespace TechnicalTest.Movie.Application.Features.Movies.Queries
{
    public class MovieBuyDto
    {
        public int Id { get; set; }
        public int MovieInventoryId { get; set; }
        public DateTime BuyDateTime { get; set; }
        public decimal BuyPrice { get; set; }
        public string UserEmail { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
