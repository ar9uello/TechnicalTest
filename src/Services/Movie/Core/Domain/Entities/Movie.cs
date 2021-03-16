using System;
using System.Collections.Generic;

namespace TechnicalTest.Movie.Domain.Entities
{
    public class Movie
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

        public ICollection<MovieInventory> MovieInventories { get; set; }
        public ICollection<MovieLike> MovieLikes { get; set; }
    }
}
