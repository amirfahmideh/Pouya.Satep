using System.Net;
using System.Net.Http.Json;
namespace Pouya.Satep;

public class AuthorizationService
{
    private readonly HttpClient httpClient;
    private readonly SatepServiceConfiguration serviceConfiguration;
    public AuthorizationService(HttpClient _httpClient, SatepServiceConfiguration _serviceConfiguration)
    {
        httpClient = _httpClient;
        serviceConfiguration = _serviceConfiguration;
    }
    public async Task<AuthorizationResult> LoginAsync()
    {
        try
        {
            httpClient.BaseAddress = new Uri(serviceConfiguration.JWTTokenServiceUrl);
            var response = await httpClient.PostAsJsonAsync(serviceConfiguration.JWTTokenServiceUrl, new AuthorizationRequest { Username = serviceConfiguration.UserName, Password = serviceConfiguration.Password });
            if (response.IsSuccessStatusCode)
            {
                var responseResult = await response.Content.ReadFromJsonAsync<ApiResponse<AuthorizationResult>>();
                if (responseResult != null && bool.Parse(responseResult.Status) == true && responseResult.Data != null && string.IsNullOrEmpty(responseResult.Errors))
                    return responseResult.Data;
                throw new UnauthorizedException();
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException();
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new BadRequestException();
            }
            else throw new Exception(response.ReasonPhrase);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
