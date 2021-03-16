using System;

namespace TechnicalTest.Movie.Application.Features.Movies.Queries
{
    public class MovieLikeDto
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string UserEmail { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
