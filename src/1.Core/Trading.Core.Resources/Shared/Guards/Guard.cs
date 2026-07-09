namespace Trading.Core.Resources.Shared.Guards;
public static class Guard
{
    public static void AgainstNull(object? value, string name)
    {
        if (value is null)
            throw new ArgumentNullException(name);
    }

    public static void AgainstNullOrWhiteSpace(string? value, string name)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException(name);
    }

    public static void AgainstNegative(decimal value, string name)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(name);
    }

    public static void AgainstNegative(int value, string name)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(name);
    }

    public static void AgainstZero(decimal value, string name)
    {
        if (value == 0)
            throw new ArgumentException(name);
    }

    public static void AgainstDefault(Guid value, string name)
    {
        if (value == Guid.Empty)
            throw new ArgumentException(name);
    }
}