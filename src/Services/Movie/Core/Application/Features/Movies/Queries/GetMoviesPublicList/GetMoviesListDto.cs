
namespace TechnicalTest.Movie.Application.Features.Movies.Queries
{
    public class GetMoviesListDto
    {
        //Movie Id
        public int Id { get; set; }
        /// <example>Superman (1978 film)</example>
        public string Title { get; set; }
        /// <example>An alien orphan is sent from his dying planet to Earth, where he grows up to become his adoptive home's first and greatest superhero.</example>
        public string Description { get; set; }
        /// <example>10</example>
        public int Stock { get; set; }
        /// <example>10</example>
        public int Likes { get; set; }
        /// <example>50</example>
        public decimal RentalPrice { get; set; }
        /// <example>500</example>
        public decimal BuyPrice { get; set; }
    }
}
