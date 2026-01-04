namespace Pouya.Satep;

public class ApiResponse<T>
{
    public string? Status { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
    public string? Errors { get; set; }
    public string? Paging { get; set; }
}