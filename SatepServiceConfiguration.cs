namespace Pouya.Satep;

public class SatepServiceConfiguration
{
    public string UserName { get; set; } = "";
    public string Password { get; set; } = "";

    public string JWTTokenServiceUrl = "https://power.scmiran.ir/api/Tavanir/Authenticate";
    public string InvoiceServicesUrl = "https://api.scmiran.ir/orders/financialInvoices";
}