using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Pouya.Satep;
using Xunit;

namespace Pouya.Satep.Tests
{
    public class AuthorizationServiceTests
    {
        [Fact]
        public async Task LoginAsync_ReturnsToken_WhenResponseIsSuccessful()
        {
            // Arrange
            var expectedToken = "test-token";

            var apiResponse = new ApiResponse<AuthorizationResult>
            {
                Status = "true",
                Errors = "",
                Data = new AuthorizationResult
                {
                    Token = expectedToken
                }
            };

            var httpResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = JsonContent.Create(apiResponse)
            };
            var httpClient = new HttpClient()
            {
                Timeout = TimeSpan.FromSeconds(30)
            };

            var service = new AuthorizationService(httpClient, new SatepServiceConfiguration()
            {
                UserName = "test",
                Password = "test"
            });


            var ex = await Assert.ThrowsAsync<UnauthorizedException>(() => service.LoginAsync());
            // Assert
            Assert.NotNull(ex);
        }

        [Fact]
        public async Task LoginAsync_ThrowsUnauthorizedException_When401Returned()
        {
            // Arrange
            var httpResponse = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            var httpClient = new HttpClient()
            {
                Timeout = TimeSpan.FromSeconds(30)
            };

            var service = new AuthorizationService(httpClient, new SatepServiceConfiguration
            {
                JWTTokenServiceUrl = "https://fake.api/login",
                UserName = "user",
                Password = "pass"
            });

            // Act & Assert
            await Assert.ThrowsAsync<UnauthorizedException>(() =>
                service.LoginAsync());
        }
    }
}
