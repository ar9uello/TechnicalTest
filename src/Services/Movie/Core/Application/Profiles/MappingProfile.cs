using AutoMapper;
using TechnicalTest.Movie.Application.Features.Movies.Commands.Create;
using TechnicalTest.Movie.Application.Features.Movies.Commands.Update;
using TechnicalTest.Movie.Application.Features.Movies.Queries;
using TechnicalTest.Movie.Domain.Entities;

namespace TechnicalTest.Movie.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.Movie, CreateMovie>().ReverseMap();
            
            CreateMap<Domain.Entities.Movie, UpdateMovie>().ReverseMap();
            CreateMap<UpdateMovie, Domain.Entities.Movie>().ReverseMap();

            CreateMap<UpdateMovieAvailability, Domain.Entities.Movie>().ReverseMap();
            CreateMap<Domain.Entities.Movie, UpdateMovieAvailabilityResponseDto>().ReverseMap();

            CreateMap<Domain.Entities.Movie, GetMoviesAdminListDto>().ReverseMap();
            CreateMap<Domain.Entities.Movie, GetMoviesListDto>().ReverseMap();

            CreateMap<CreateMovieLike, MovieLike>().ReverseMap();
            CreateMap<CreateMovieRental, MovieRental>().ReverseMap();
            CreateMap<CreateMovieBuy, MovieBuy>().ReverseMap();

            CreateMap< Domain.Entities.Movie, MovieDto>().ReverseMap();
            CreateMap<MovieInventory, MovieInventoryDto>().ReverseMap();
            CreateMap<MovieRental, MovieRentalDto>().ReverseMap();
            CreateMap<MovieBuy, MovieBuyDto>().ReverseMap();
            CreateMap<MovieLike, MovieLikeDto>().ReverseMap();

            CreateMap<MovieRental, GetUsersPenaltyListDto>().ReverseMap();

        }
    }
}
