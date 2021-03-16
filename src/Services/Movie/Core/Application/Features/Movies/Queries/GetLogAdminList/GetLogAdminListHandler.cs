using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TechnicalTest.Movie.Application.Contracts.Identity;
using TechnicalTest.Movie.Application.Contracts.Persistence;
using TechnicalTest.Movie.Application.Exceptions;

namespace TechnicalTest.Movie.Application.Features.Movies.Queries
{
    public class GetLogAdminListHandler : IRequestHandler<GetLogAdminList, GetLogAdminListResponse>
    {
        
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIdentityService _identityService;

        public GetLogAdminListHandler(IMapper mapper, IUnitOfWork unitOfWork, IIdentityService identityService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _identityService = identityService;
        }

        public async Task<GetLogAdminListResponse> Handle(GetLogAdminList request, CancellationToken cancellationToken)
        {
            //Validate Role Admin
            if (!_identityService.IsUserAdmin()) throw new ForbiddenException();

            //Process Data
            var data = await _unitOfWork.MovieRepository.GetByIdAsync(request.MovieId);
            var movie = _mapper.Map<MovieDto>(data);

            var movieRentalsList = await _unitOfWork.MovieRentalRepository.GetMovieRentals(request.MovieId);
            var movieRentals = _mapper.Map<List<MovieRentalDto>>(movieRentalsList);

            var movieBuysList = await _unitOfWork.MovieBuyRepository.GetMovieBuys(request.MovieId);
            var movieBuys = _mapper.Map<List<MovieBuyDto>>(movieBuysList);

            var movieLikesList = await _unitOfWork.MovieLikeRepository.GetMovieLikes(request.MovieId);
            var movieLikes = _mapper.Map<List<MovieLikeDto>>(movieLikesList);

            var MovieInventoriesList = await _unitOfWork.MovieInventoryRepository.GetMovieLikes(request.MovieId);
            var movieInventories = _mapper.Map<List<MovieInventoryDto>>(MovieInventoriesList);

            return new GetLogAdminListResponse() { Data = new GetLogAdminListResponseData { Movie = movie, MovieRentals = movieRentals, MovieBuys = movieBuys, MovieLikes = movieLikes, MovieInventories = movieInventories } };
        }
    }
}
