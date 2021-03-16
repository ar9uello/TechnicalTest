using System;

namespace TechnicalTest.Movie.Application.Features.Movies.Queries
{
    public class MovieInventoryDto
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string InventoryCode { get; set; }
        public int MovieInventoryStatusId { get; set; }
        public string UserEmail { get; set; }
        public DateTime EntryDate { get; set; }

    }
}
