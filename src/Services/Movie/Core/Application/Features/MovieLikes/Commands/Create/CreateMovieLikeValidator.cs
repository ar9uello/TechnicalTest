using FluentValidation;
using System.Threading;
using System.Threading.Tasks;
using TechnicalTest.Movie.Application.Contracts.Persistence;
using TechnicalTest.Movie.Domain.Entities;

namespace TechnicalTest.Movie.Application.Features.Movies.Commands.Create
{
    public class CreateMovieLikeValidator : AbstractValidator<MovieLike>
    {
        private readonly IMovieLikeRepository _repository;

        public CreateMovieLikeValidator(IMovieLikeRepository repository)
        {
            _repository = repository;

            RuleFor(p => p.MovieId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than '0'.");

            RuleFor(p => p)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MustAsync(IsMovieLikeUnique).WithMessage("A like with the same email already exists.");
        }

        private async Task<bool> IsMovieLikeUnique(MovieLike e, CancellationToken token)
        {
            return await _repository.IsMovieLikeUnique(e);
        }

    }
}
