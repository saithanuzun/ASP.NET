namespace Error_Handling.Exceptions;

public class CustomException : Exception
{
    public CustomException() : base()
    {
        
    }

    public CustomException(string? message) : base(message)
    {
        
    }

    public CustomException(string? message, Exception? ex) : base(message,ex)
    {
        
    }
}