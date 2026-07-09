namespace Trading.Core.Resources.Shared.Results;


public class Result
{
    protected Result(bool succeeded, string? error)
    {
        Succeeded = succeeded;
        Error = error;
    }

    public bool Succeeded { get; }

    public bool Failed => !Succeeded;

    public string? Error { get; }

    public static Result Success()
        => new(true, null);

    public static Result Failure(string error)
        => new(false, error);
}
public sealed class Result<T> : Result
{
    private Result(T? value, bool succeeded, string? error)
        : base(succeeded, error)
    {
        Value = value;
    }

    public T? Value { get; }

    public static Result<T> Success(T value)
        => new(value, true, null);

    public static new Result<T> Failure(string error)
        => new(default, false, error);
}