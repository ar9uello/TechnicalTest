using System.Collections.Generic;

namespace TechnicalTest.Movie.Application.Features.Movies.Queries
{
    public class GetLogAdminListResponseData 
    {
        public MovieDto Movie { get; set; }
        public List<MovieInventoryDto> MovieInventories { get; set; }
        public List<MovieRentalDto> MovieRentals { get; set; }
        public List<MovieBuyDto> MovieBuys { get; set; }
        public List<MovieLikeDto> MovieLikes { get; set; }
    }
}
