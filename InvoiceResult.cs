using System.Dynamic;

namespace Pouya.Satep;

public class InvoiceResult
{
    public List<Invoice> FinancialInvoices { get; set; } = [];
    public long Total { get; set; } = 0;

}

public class Invoice
{
    public long Id { get; set; }
    public long TrackingCode { get; set; }
    public string CustomerFirstName { get; set; } = default!;
    public string CustomerLastName { get; set; } = default!;
    /// <summary>
    /// نوع شخص خریدار
    /// </summary>
    /// example 0 = حقیقی
    /// example 1 = حقوقی
    public bool CustomerType = true;
    public string CustomerNationalCode { get; set; } = default!;
    public string CustomerMobile { get; set; } = default!;
    public string CustomerAddress { get; set; } = default!;
    public string CustomerPostalCode { get; set; } = default!;
    public string SellerName { get; set; } = default!;
    public string SellerNationalCode { get; set; } = default!;
    public string SellerAddress { get; set; } = default!;
    public string SellerPostalCode { get; set; } = default!;
    /// <summary>
    /// نوع فاکتور
    /// </summary>
    /// example 0 = اصلی
    /// example 1 = برگشت از فروش
    /// example 2 = ابطالی
    public int InvoiceType { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime PaymentDate { get; set; }
    public List<Activity> Activities { get; set; } = [];
    public decimal ShippingCost { get; set; } = 0;
    public decimal TotalTax { get; set; } = 0;
    /// <summary>
    /// مبلغ کل فاکتور با مالیات بر ارزش افزوده
    /// </summary>
    public decimal TotalAmount { get; set; } = 0;
    /// <summary>
    /// روش پرداخت
    /// </summary>
    /// example false = آنلاین
    /// example true = شناسه واریز
    public bool PaymentType { get; set; } = false;
    /// <summary>
    /// شماره پیگیری پرداخت
    /// </summary>
    public long PaymentTrackingCode { get; set; } = 0;
    /// <summary>
    /// شماره کارت واریز کننده
    /// </summary>
    public string CustomerCardNumber { get; set; } = default!;
    /// <summary>
    /// شماره کارت/ شماره شبا استرداد شده
    /// </summary>
    public string RefundIBAN { get; set; } = default!;
}

public class Activity
{
    public int ActivityId { get; set; }
    public string ActivityName { get; set; } = default!;
    public int Count { get; set; }
    public decimal UnitAmount { get; set; }
    public decimal Tax { get; set; }
    public decimal ActivityTotalAmount { get; set; }
    /// <summary>
    /// نوع تجهیز و یا خدمت
    /// </summary>
    /// example false = تجهیز
    /// example true = خدمت
    public bool ActivityType { get; set; }
}