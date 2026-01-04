namespace Pouya.Satep;

public class ApiResponse<T>
{
    public bool? Status { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
    public object? Errors { get; set; }
    public object? Paging { get; set; }
}