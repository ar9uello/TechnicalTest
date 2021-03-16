using MediatR;
using System;

namespace TechnicalTest.Movie.Application.Features.Movies.Commands.Update
{
    public class UpdateMovie : IRequest<UpdateMovieResponse>
    {

        //Movie Id
        public int Id { get; set; }
        /// <example>Superman (1978 film)</example>
        public string Title { get; set; }
        /// <example>An alien orphan is sent from his dying planet to Earth, where he grows up to become his adoptive home's first and greatest superhero.</example>
        public string Description { get; set; }
        /// <example>50</example>
        public decimal RentalPrice { get; set; }
        /// <example>500</example>
        public decimal BuyPrice { get; set; }

        public bool Availability { get; set; }

        public override string ToString()
        {
            return $"Movie Title: {Title};";
        }
    }
}
