using FluentValidation;

namespace TechnicalTest.Movie.Application.Features.Movies.Commands.Update
{
    public class UpdateMovieAvailabilityValidator : AbstractValidator<UpdateMovieAvailability>
    {
        public UpdateMovieAvailabilityValidator()
        {

            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than '0'.");

            RuleFor(p => p.Availability)
                .Must(x => x == false || x == true).WithMessage("{PropertyName} is required.");

        }

    }
}
