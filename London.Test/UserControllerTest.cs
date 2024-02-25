using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using London.Api.Models.Requests;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;
using London.Api;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace London.Test
{
    public class UserControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public UserControllerTest(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task SignUp_ReturnsOk_WhenUserIsSuccessfullyCreated()
        {
            var request = new SignUpRequestModel
            {
                Username = "testUser",
                Password = "TestPassword123",
            };
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/user/sign-up", content);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Login_ReturnsOk_WithToken_WhenCredentialsAreValid()
        {
            var request = new LoginRequestModel
            {
                Username = "validUser",
                Password = "validPassword"
            };
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/user/login", content);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var responseContent = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(responseContent);
            Assert.NotNull(result.AccessToken);
        }
    }
}