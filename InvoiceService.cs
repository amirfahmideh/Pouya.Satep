using System.Net;
using System.Net.Http.Json;
namespace Pouya.Satep;

public class InvoiceService
{
    private readonly HttpClient httpClient;
    private readonly SatepServiceConfiguration serviceConfiguration;
    public InvoiceService(HttpClient _httpClient, SatepServiceConfiguration _serviceConfiguration)
    {
        httpClient = _httpClient;
        serviceConfiguration = _serviceConfiguration;
    }

    public async Task AddAuthorizationBearerAsync()
    {
        AuthorizationService authorizationService = new AuthorizationService(httpClient, serviceConfiguration);
        try
        {
            var result = await authorizationService.LoginAsync();
            if (result != null && !string.IsNullOrEmpty(result.Token))
            {
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", result.Token);
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public async Task<InvoiceResult?> GetInvoiceAsync(InvoiceRequest invoiceRequest)
    {
        try
        {
            await AddAuthorizationBearerAsync();
            var response = await httpClient.GetAsync($"{serviceConfiguration.InvoiceServicesUrl}{invoiceRequest.ToQueryString()}");
            if (response.IsSuccessStatusCode)
            {
                var responseResult = await response.Content.ReadFromJsonAsync<InvoiceResult>();
                return responseResult;
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
