using System;

namespace TechnicalTest.Movie.Domain.Entities
{
    public class MovieBuy
    {
        public int Id { get; set; }
        public int MovieInventoryId { get; set; }
        public DateTime BuyDateTime { get; set; }
        public decimal BuyPrice { get; set; }
        public string UserEmail { get; set; }
        public DateTime EntryDate { get; set; }

        public MovieInventory MovieInventory { get; set; }
    }
}
