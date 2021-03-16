using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TechnicalTest.Movie.Application.Contracts.Persistence;
using TechnicalTest.Movie.Application.Features.Users.Queries.GetUsersPenaltyList;

namespace TechnicalTest.Movie.Application.Features.Movies.Queries
{
    public class GetUsersPenaltyListHandler : IRequestHandler<GetUsersPenaltyList, GetUsersPenaltyListVm>
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetUsersPenaltyListHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetUsersPenaltyListVm> Handle(GetUsersPenaltyList request, CancellationToken cancellationToken)
        {
            //Process Data
            var list = await _unitOfWork.MovieRentalRepository.GetUsersPenalty();
            var data = _mapper.Map<List<GetUsersPenaltyListDto>>(list);

            return new GetUsersPenaltyListVm() { Data = data };
        }
    }
}
