using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TechnicalTest.Movie.Application.Contracts.Identity;
using TechnicalTest.Movie.Application.Contracts.Persistence;

namespace TechnicalTest.Movie.Application.Features.Movies.Queries
{
    public class GetMoviesListHandler : IRequestHandler<GetMoviesList, GetMoviesListVm>
    {
        
        private readonly IMapper _mapper;
        private readonly IMovieRepository _repository;
        private readonly IIdentityService _identityService;

        public GetMoviesListHandler(IMapper mapper, IMovieRepository repository, IIdentityService identityService)
        {
            _mapper = mapper;
            _repository = repository;
            _identityService = identityService;
        }

        public async Task<GetMoviesListVm> Handle(GetMoviesList request, CancellationToken cancellationToken)
        {
            //Process Data
            var list = await _repository.GetPagedMovies(request.Page, request.Size, request.Sort, request.Search, true);
            var data = _mapper.Map<List<GetMoviesListDto>>(list);

            var count = await _repository.GetTotalCountOfMovies(request.Search, true);
            return new GetMoviesListVm() { Count = count, Page = request.Page, Size = request.Size, Data = data };
        }
    }
}
