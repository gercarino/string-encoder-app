namespace OneInc.API.Common;

public abstract class Result
{
    public bool Success { get; protected set; }
    public bool Failure => !Success;
}

public abstract class Result<T> : Result
{
    protected Result(T data)
    {
        Data = data;
    }

    public T Data { get; }
}

public class SuccessResult : Result
{
    public SuccessResult()
    {
        Success = true;
    }
}

public class SuccessResult<T> : Result<T>
{
    public SuccessResult(T data) : base(data)
    {
        Success = true;
    }
}

public class ErrorResult : Result
{
    public ErrorResult(string message) : this(message, new List<string>())
    {
    }

    public ErrorResult(string message, List<string> errors)
    {
        Message = message;
        Success = false;
        Errors = errors ?? new List<string>();
    }

    public string Message { get; }
    public IReadOnlyCollection<string> Errors { get; }
}

public class ErrorResult<T> : Result<T>
{
    public ErrorResult(string message, IReadOnlyCollection<string> errors, T data) : base(data)
    {
        Message = message;
        Success = false;
        Errors = errors ?? Array.Empty<string>();
    }

    public string Message { get; }
    public IReadOnlyCollection<string> Errors { get; }
}