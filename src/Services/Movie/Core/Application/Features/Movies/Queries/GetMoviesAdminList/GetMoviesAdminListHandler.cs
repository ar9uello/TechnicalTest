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
    public class GetMoviesAdminListHandler : IRequestHandler<GetMoviesAdminList, GetMoviesAdminListVm>
    {
        
        private readonly IMapper _mapper;
        private readonly IMovieRepository _repository;
        private readonly IIdentityService _identityService;

        public GetMoviesAdminListHandler(IMapper mapper, IMovieRepository repository, IIdentityService identityService)
        {
            _mapper = mapper;
            _repository = repository;
            _identityService = identityService;
        }

        public async Task<GetMoviesAdminListVm> Handle(GetMoviesAdminList request, CancellationToken cancellationToken)
        {
            //Validate Role Admin
            if (!_identityService.IsUserAdmin()) throw new ForbiddenException();

            //Process Data
            var list = await _repository.GetPagedMovies(request.Page, request.Size, request.Sort, request.Search, request.Availability);
            var data = _mapper.Map<List<GetMoviesAdminListDto>>(list);

            var count = await _repository.GetTotalCountOfMovies(request.Search, request.Availability);
            return new GetMoviesAdminListVm() { Count = count, Page = request.Page, Size = request.Size, Data = data };
        }
    }
}
