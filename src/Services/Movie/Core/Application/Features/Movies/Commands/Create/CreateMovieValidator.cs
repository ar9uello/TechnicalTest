using FluentValidation;

namespace TechnicalTest.Movie.Application.Features.Movies.Commands.Create
{
    public class CreateMovieValidator : AbstractValidator<CreateMovie>
    {
        public CreateMovieValidator()
        {

            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.RentalPrice)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than '0'.");

            RuleFor(p => p.BuyPrice)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than '0'.");

            RuleFor(p => p.Availability)
                .Must(x => x == false || x == true).WithMessage("{PropertyName} is required.");

        }

    }
}
