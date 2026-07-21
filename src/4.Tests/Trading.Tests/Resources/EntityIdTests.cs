using Trading.Core.Resources.Shared.Interfaces;

namespace Trading.Tests.Resources;

public sealed class EntityIdTests
{
    [Fact]
    public void CompareTo_WithSameGuid_ReturnsZero()
    {
        var value = Guid.CreateVersion7();
        var id = new TestEntityId(value);

        var result = id.CompareTo(value);

        Assert.Equal(0, result);
    }

    [Fact]
    public void ToType_WhenConvertingToGuid_ReturnsUnderlyingValue()
    {
        var value = Guid.CreateVersion7();
        var id = new TestEntityId(value);

        var result = id.ToType(typeof(Guid), null);

        Assert.Equal(value, result);
    }

    private sealed record TestEntityId(Guid Value)
        : EntityId(Value);
}
