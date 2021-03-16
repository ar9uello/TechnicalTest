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
    public class CreateMovieLikeHandler : IRequestHandler<CreateMovieLike, BaseResponse>
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIdentityService _identityService;

        public CreateMovieLikeHandler(IMapper mapper, IUnitOfWork unitOfWork, IIdentityService identityService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork; 
            _identityService = identityService;
        }


        public async Task<BaseResponse> Handle(CreateMovieLike request, CancellationToken cancellationToken)
        {
            //Validate Role Admin
            if (!_identityService.IsUserRole()) throw new ForbiddenException();

            //Validate Data Exists
            var movie = await _unitOfWork.MovieRepository.GetByIdAsync(request.MovieId);
            if (movie == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Movie), request.MovieId);
            }

            //Process Data
            var response = new BaseResponse();
            var userEmail = _identityService.GetUserEmail();

            var data = _mapper.Map<MovieLike>(request);
            data.UserEmail = userEmail;
            data.EntryDate = DateTime.Now;

            //Validate Data
            var validator = new CreateMovieLikeValidator(_unitOfWork.MovieLikeRepository);
            var validationResult = await validator.ValidateAsync(data);
            if (validationResult.Errors.Count > 0) throw new ValidationException(validationResult);

            await _unitOfWork.MovieLikeRepository.CreateMovieLike(data);

            return response;

        }

    }
}
