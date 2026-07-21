using Trading.Core.Resources.Shared.Results;

namespace Trading.Tests.Resources;

public sealed class ResultTests
{
    [Fact]
    public void Success_ReturnsSucceededResult()
    {
        var result = Result.Success();

        Assert.True(result.Succeeded);
        Assert.False(result.Failed);
        Assert.Null(result.Error);
    }

    [Fact]
    public void Failure_ReturnsFailedResultWithError()
    {
        var result = Result.Failure("error");

        Assert.False(result.Succeeded);
        Assert.True(result.Failed);
        Assert.Equal("error", result.Error);
    }

    [Fact]
    public void GenericSuccess_ReturnsValue()
    {
        var result = Result<int>.Success(42);

        Assert.True(result.Succeeded);
        Assert.Equal(42, result.Value);
    }
}
