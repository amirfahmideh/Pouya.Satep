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

    public async Task<InvoiceResult?> GetInvoiceAsync()
    {
        try
        {
            var response = await httpClient.GetAsync(serviceConfiguration.InvoiceServicesUrl);
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
