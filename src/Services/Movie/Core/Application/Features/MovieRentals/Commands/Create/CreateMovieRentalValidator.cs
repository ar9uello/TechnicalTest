using FluentValidation;
using System.Threading;
using System.Threading.Tasks;
using TechnicalTest.Movie.Application.Contracts.Persistence;
using TechnicalTest.Movie.Domain.Entities;

namespace TechnicalTest.Movie.Application.Features.Movies.Commands.Create
{
    public class CreateMovieRentalValidator : AbstractValidator<MovieRental>
    {
        private readonly IMovieInventoryRepository _repository;

        public CreateMovieRentalValidator(IMovieInventoryRepository repository)
        {
            _repository = repository;

            RuleFor(p => p.MovieInventoryId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than '0'.");

            RuleFor(p => p.RentalBeginDateTime)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.RentalEndDateTime)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.RentalPrice)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than '0'.")
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p)
                .MustAsync(IsStatusInventory).WithMessage("It is not possible to rent this item because it has no inventory status.");
        }

        private async Task<bool> IsStatusInventory(MovieRental e, CancellationToken token)
        {
            return (e.MovieInventoryId != 0 ? await _repository.IsStatusInventory(e.MovieInventoryId) : true);
        }

    }
}
