namespace NexusCRM.Web;

public class Result<T>
{
    public bool IsSuccess { get; init; }
    public string? Message { get; init; }
    public T? Data { get; init; } 
    public static Result<T> Fail(string message)
        => new () { Message = message , IsSuccess = false };
    public static Result<T> Success(T data)
        => new (){ Data = data, IsSuccess = true };
    public static Result<T> Success()
        => new() { IsSuccess = true };
}
