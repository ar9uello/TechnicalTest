using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TechnicalTest.Movie.Application.Contracts.Identity;
using TechnicalTest.Movie.Application.Contracts.Persistence;
using TechnicalTest.Movie.Application.Exceptions;
using TechnicalTest.Movie.Application.Responses;
using TechnicalTest.Movie.Domain.Entities;

namespace TechnicalTest.Movie.Application.Features.Movies.Commands.Create
{
    public class CreateMovieBuyHandler : IRequestHandler<CreateMovieBuy, BaseResponse>
    {

        private readonly IMapper _mapper;
        private readonly IMovieInventoryRepository _movieInventoryRepository;
        private readonly IMovieBuyRepository _MovieBuyRepository;
        private readonly IIdentityService _identityService;

        public CreateMovieBuyHandler(IMapper mapper, IMovieInventoryRepository movieInventoryRepository, IMovieBuyRepository MovieBuyRepository, IIdentityService identityService)
        {
            _mapper = mapper;
            _movieInventoryRepository = movieInventoryRepository;
            _MovieBuyRepository = MovieBuyRepository;
            _identityService = identityService;
        }


        public async Task<BaseResponse> Handle(CreateMovieBuy request, CancellationToken cancellationToken)
        {
            //Validate Role Admin
            if (!_identityService.IsUserRole()) throw new ForbiddenException();

            //Process Data
            var response = new BaseResponse();
            var userEmail = _identityService.GetUserEmail();

            var data = _mapper.Map<MovieBuy>(request);
            data.UserEmail = userEmail;
            data.EntryDate = DateTime.Now;

            //Validate Data
            var validator = new CreateMovieBuyValidator(_movieInventoryRepository);
            var validationResult = await validator.ValidateAsync(data);
            if (validationResult.Errors.Count > 0) throw new ValidationException(validationResult);

            await _MovieBuyRepository.CreateMovieBuy(data);

            return response;

        }

    }
}
