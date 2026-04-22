namespace N52_HT1.Models;

public class ServiceResult
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; } = string.Empty;

    public static ServiceResult Success(string message = "")
        => new() { IsSuccess = true, Message = message };

    public static ServiceResult Failure(string message)
        => new() { IsSuccess = false, Message = message };
}

public class ServiceResult<T> : ServiceResult
{
    public T? Data { get; set; }

    public static ServiceResult<T> Success(T data, string message = "")
        => new() { IsSuccess = true, Data = data, Message = message };

    public static ServiceResult<T> Failure(string message)
        => new() { IsSuccess = false, Message = message };
}