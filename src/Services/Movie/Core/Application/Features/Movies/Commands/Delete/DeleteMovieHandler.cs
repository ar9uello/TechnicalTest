using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TechnicalTest.Movie.Application.Contracts.Identity;
using TechnicalTest.Movie.Application.Contracts.Persistence.Base;
using TechnicalTest.Movie.Application.Exceptions;
using TechnicalTest.Movie.Application.Responses;

namespace TechnicalTest.Movie.Application.Features.Movies.Commands.Delete
{
    public class DeleteMovieHandler : IRequestHandler<DeleteMovie, BaseResponse>
    {

        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Domain.Entities.Movie> _repository;
        private readonly IIdentityService _identityService;

        public DeleteMovieHandler(IMapper mapper, IAsyncRepository<Domain.Entities.Movie> repository, IIdentityService identityService)
        {
            _mapper = mapper;
            _repository = repository;
            _identityService = identityService;
        }


        public async Task<BaseResponse> Handle(DeleteMovie request, CancellationToken cancellationToken)
        {
            //Validate Role Admin
            if (!_identityService.IsUserAdmin()) throw new ForbiddenException();

            var data = await _repository.GetByIdAsync(request.MovieId);

            if (data == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Movie), request.MovieId);
            }

            await _repository.DeleteAsync(data);

            return new BaseResponse(); ;

        }

    }
}
