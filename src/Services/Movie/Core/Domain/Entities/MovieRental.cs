using System;

namespace TechnicalTest.Movie.Domain.Entities
{
    public class MovieRental
    {
        public int Id { get; set; }
        public int MovieInventoryId { get; set; }
        public DateTime RentalBeginDateTime { get; set; }
        public DateTime RentalEndDateTime { get; set; }
        public DateTime? ReturnDateTime { get; set; }
        public decimal RentalPrice { get; set; }
        public string UserEmail { get; set; }
        public DateTime EntryDate { get; set; }

        public MovieInventory MovieInventory { get; set; }
    }
}
