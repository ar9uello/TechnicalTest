using System;

namespace TechnicalTest.Movie.Domain.Entities
{
    public class MovieInventory
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string InventoryCode { get; set; }
        public int MovieInventoryStatusId { get; set; }
        public string UserEmail { get; set; }
        public DateTime EntryDate { get; set; }

        public Movie Movie { get; set; }
        public MovieInventoryStatus MovieInventoryStatuses { get; set; }
    }
}
