namespace Pouya.Satep;

public class InvoiceRequest
{
    /// <summary>
    /// تاریخ شروع
    /// </summary>
    public DateTime FromPaymentDate { get; set; } = default!;
    /// <summary>
    /// تاریخ پایان بیشتر از ۷ روز نمی تواند باشد
    /// </summary>
    public DateTime ToPaymentDate { get; set; } = default!;
    /// <summary>
    /// صفحه بندی
    /// </summary>
    public long PageId { get; set; } = 1;
    /// <summary>
    /// تعداد در صفحه
    /// </summary>
    public int Top { get; set; } = 10;

    public string ToQueryString()
    {
        return $"?fromPaymentDate={FromPaymentDate:YYYYMMDD}&toPaymentDate={ToPaymentDate:YYYYMMDD}&pageId={PageId}&top={Top}";
    }
}