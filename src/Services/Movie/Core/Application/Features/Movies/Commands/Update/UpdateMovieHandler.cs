using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TechnicalTest.Movie.Application.Contracts.Identity;
using TechnicalTest.Movie.Application.Contracts.Persistence.Base;
using TechnicalTest.Movie.Application.Exceptions;

namespace TechnicalTest.Movie.Application.Features.Movies.Commands.Update
{
    public class UpdateMovieHandler : IRequestHandler<UpdateMovie, UpdateMovieResponse>
    {

        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Domain.Entities.Movie> _repository;
        private readonly IIdentityService _identityService;

        public UpdateMovieHandler(IMapper mapper, IAsyncRepository<Domain.Entities.Movie> repository, IIdentityService identityService)
        {
            _mapper = mapper;
            _repository = repository;
            _identityService = identityService;
        }


        public async Task<UpdateMovieResponse> Handle(UpdateMovie request, CancellationToken cancellationToken)
        {
            //Validate Role Admin
            if (!_identityService.IsUserAdmin()) throw new ForbiddenException();

            //Validate Data Exists
            var data = await _repository.GetByIdAsync(request.Id);
            if (data == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Movie), request.Id);
            }

            //Validate Data
            var validator = new UpdateMovieValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0) throw new ValidationException(validationResult);

            //Process Data
            var response = new UpdateMovieResponse();
            if (response.Success)
            {

                _mapper.Map(request, data, typeof(UpdateMovie), typeof(Domain.Entities.Movie));
                await _repository.UpdateAsync(data);

                _mapper.Map(data, request, typeof(Domain.Entities.Movie), typeof(UpdateMovie));
                response.Data = request;
            }

            return response;

        }

    }
}
