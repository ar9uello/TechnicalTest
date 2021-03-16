using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TechnicalTest.Movie.Application.Contracts.Identity;
using TechnicalTest.Movie.Application.Contracts.Persistence.Base;
using TechnicalTest.Movie.Application.Exceptions;

namespace TechnicalTest.Movie.Application.Features.Movies.Commands.Create
{
    public class CreateMovieHandler : IRequestHandler<CreateMovie, CreateMovieResponse>
    {

        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Domain.Entities.Movie> _repository;
        private readonly IIdentityService _identityService;

        public CreateMovieHandler(IMapper mapper, IAsyncRepository<Domain.Entities.Movie> repository, IIdentityService identityService)
        {
            _mapper = mapper;
            _repository = repository;
            _identityService = identityService;
        }


        public async Task<CreateMovieResponse> Handle(CreateMovie request, CancellationToken cancellationToken)
        {
            //Validate Role Admin
            if (!_identityService.IsUserAdmin()) throw new ForbiddenException();

            //Validate Data
            var validator = new CreateMovieValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0) throw new ValidationException(validationResult);

            //Process Data
            var response = new CreateMovieResponse();
            if (response.Success)
            {
                var userEmail = _identityService.GetUserEmail();

                var data = _mapper.Map<Domain.Entities.Movie>(request);

                data.UserEmail = userEmail;
                data.EntryDate = DateTime.Now;

                data = await _repository.AddAsync(data);

                response.Data = new CreateMovieResponseDto { MovieId = data.Id };
            }

            return response;

        }

    }
}
