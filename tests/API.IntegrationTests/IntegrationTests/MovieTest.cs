using API.IntegrationTests.Base;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using TechnicalTest.Movie.Application.Features.Movies.Commands.Create;
using TechnicalTest.Movie.Application.Features.Movies.Commands.Update;
using Xunit;
using Xunit.Abstractions;

namespace API.IntegrationTests
{
    public class MovieTest : TestBase
    {

        public MovieTest(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        [Fact]
        public async Task Create_Movie_Tests()
        {

            TestOutputHelper.WriteLine("Unauthorized");
            Assert.Equal(HttpStatusCode.Unauthorized, (await CreateMovie()).statusCode);

            TestOutputHelper.WriteLine("Forbidden");
            await SetUserToken();
            Assert.Equal(HttpStatusCode.Forbidden, (await CreateMovie()).statusCode);

            TestOutputHelper.WriteLine("Get/Set Token");
            await SetAdminToken();

            TestOutputHelper.WriteLine("Create Movie");
            var (statusCode, movieId) = await CreateMovie();
            Assert.Equal(HttpStatusCode.Created, statusCode);

            TestOutputHelper.WriteLine("UpdateMovie");
            var updateMovie = await UpdateMovie(movieId);
            Assert.Equal(HttpStatusCode.OK, updateMovie);

            TestOutputHelper.WriteLine("UpdateMovieAvailability");
            var updateMovieAvailability = await UpdateMovieAvailability(movieId);
            Assert.Equal(HttpStatusCode.OK, updateMovieAvailability);

            TestOutputHelper.WriteLine("DeleteMovie");
            var deleteMovie = await DeleteMovie(movieId);
            Assert.Equal(HttpStatusCode.OK, deleteMovie);

        }

        private async Task<(HttpStatusCode statusCode, int movieId)> CreateMovie()
        {

            var body = new CreateMovie()
            {
                Title = "The Lord of the Rings",
                Description = "The Lord of the Rings is a film series of three epic fantasy adventure films directed by Peter Jackson, based on the novel written by J. R. R. Tolkien. ",
                RentalPrice = 50,
                BuyPrice = 500,
                Availability = true
            };

            var response = await Post(MovieClient, "/api/v1/Movies/Admin", body);

            if (response.StatusCode == HttpStatusCode.Created)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<CreateMovieResponse>(responseContent);
                return (response.StatusCode, json.Data.MovieId);
            }

            return (response.StatusCode, 0);
        }

        private async Task<HttpStatusCode> UpdateMovie(int id)
        {

            var body = new UpdateMovie()
            {
                Id = id,
                Title = "The Lord of the Rings",
                Description = "The Lord of the Rings is a film series of three epic fantasy adventure films.",
                RentalPrice = 51,
                BuyPrice = 501,
                Availability = true
            };

            return (await Put(MovieClient, "/api/v1/Movies/Admin", body)).StatusCode;

        }

        private async Task<HttpStatusCode> UpdateMovieAvailability(int id)
        {

            var body = new UpdateMovieAvailability()
            {
                Id = id,
                Availability = false
            };

            return (await Patch(MovieClient, "/api/v1/Movies/Admin", body)).StatusCode;

        }

        private async Task<HttpStatusCode> DeleteMovie(int id)
        {
            return (await Delete(MovieClient, $"/api/v1/Movies/Admin/{id}")).StatusCode;
        }

    }
}
