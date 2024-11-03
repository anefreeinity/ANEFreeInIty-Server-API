namespace ANEFreeInIty_Server_API.Model.Dtos.Error;

public class ErrorDetails
{
    public int StatusCode { get; set; }
    public string? Message { get; set; } = string.Empty;
}