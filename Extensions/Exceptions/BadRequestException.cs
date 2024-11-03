namespace ANEFreeInIty_Server_API.Extensions.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message)
    {
    }
}