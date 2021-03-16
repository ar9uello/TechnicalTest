using System;

namespace TechnicalTest.Movie.Domain.Entities
{
    public class MovieLike
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string UserEmail { get; set; }
        public DateTime EntryDate { get; set; }

        public Movie Movie { get; set; }
    }
}
