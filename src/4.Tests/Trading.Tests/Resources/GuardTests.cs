using Trading.Core.Resources.Shared.Guards;

namespace Trading.Tests.Resources;

public sealed class GuardTests
{
    [Fact]
    public void AgainstNull_WhenValueIsNull_Throws()
    {
        Assert.Throws<ArgumentNullException>(() => Guard.AgainstNull(null, "value"));
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void AgainstNullOrWhiteSpace_WhenInvalid_Throws(string value)
    {
        Assert.Throws<ArgumentException>(() => Guard.AgainstNullOrWhiteSpace(value, "value"));
    }

    [Fact]
    public void AgainstNegative_WhenDecimalIsNegative_Throws()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Guard.AgainstNegative(-1m, "value"));
    }

    [Fact]
    public void AgainstZero_WhenDecimalIsZero_Throws()
    {
        Assert.Throws<ArgumentException>(() => Guard.AgainstZero(0, "value"));
    }

    [Fact]
    public void AgainstDefault_WhenGuidIsEmpty_Throws()
    {
        Assert.Throws<ArgumentException>(() => Guard.AgainstDefault(Guid.Empty, "value"));
    }
}
