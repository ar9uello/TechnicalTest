using MediatR;

namespace TechnicalTest.Movie.Application.Features.Movies.Commands.Update
{
    public class UpdateMovieAvailability : IRequest<UpdateMovieAvailabilityResponse>
    {

        //Movie Id
        public int Id { get; set; }
        /// <example>true</example>
        public bool Availability { get; set; }

    }
}
