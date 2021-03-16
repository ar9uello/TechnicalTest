using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TechnicalTest.Identity.Application.Models.Authentication;
using Xunit;
using Xunit.Abstractions;

namespace API.IntegrationTests.Base
{
    public abstract class TestBase
    {
        protected readonly HttpClient IdentityClient;
        protected readonly HttpClient MovieClient;
        protected readonly ITestOutputHelper TestOutputHelper;

        public TestBase(ITestOutputHelper testOutputHelper)
        {
            var identityFactory = new IdentityWebApplicationFactory();
            var movieFactory = new MovieWebApplicationFactory();
            IdentityClient = identityFactory.CreateClient();
            MovieClient = movieFactory.CreateClient();
            TestOutputHelper = testOutputHelper;
        }

        protected async Task SetAdminToken()
        {
            await SetToken("admin");
        }

        protected async Task SetUserToken()
        {
            await SetToken("user");
        }

        protected async Task SetToken(string user)
        {

            var body = new AuthenticationRequest()
            {
                UserName = user,
                Password = "Applaudo&01!"
            };

            var response = await Post(IdentityClient, "/api/v1/Account/authenticate", body);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var responseContent = await response.Content.ReadAsStringAsync();
            var authResponse = JsonConvert.DeserializeObject<AuthenticationResponse>(responseContent);

            MovieClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authResponse.Token);

        }

        protected async Task<HttpResponseMessage> Post(HttpClient client, string requestUri, object body)
        {
            return await client.PostAsync(requestUri, ConvertBody(body));
        }

        protected async Task<HttpResponseMessage> Put(HttpClient client, string requestUri, object body)
        {
            return await client.PutAsync(requestUri, ConvertBody(body));
        }

        protected async Task<HttpResponseMessage> Patch(HttpClient client, string requestUri, object body)
        {
            return await client.PatchAsync(requestUri, ConvertBody(body));
        }

        protected async Task<HttpResponseMessage> Delete(HttpClient client, string requestUri)
        {
            return await client.DeleteAsync(requestUri);
        }

        private ByteArrayContent ConvertBody(object body)
        {
            var myContent = JsonConvert.SerializeObject(body);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return byteContent;
        }
    }
}
