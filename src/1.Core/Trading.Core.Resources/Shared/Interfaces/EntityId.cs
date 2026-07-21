namespace Trading.Core.Resources.Shared.Interfaces;

public abstract record EntityId(Guid Value) : IComparable, IComparable<Guid>, IConvertible, IEquatable<Guid>, IFormattable
{
    public static Guid NewId()
        => Guid.CreateVersion7();

    public int CompareTo(Guid other)
        => Value.CompareTo(other);

    public virtual bool Equals(Guid other)
        => Value.Equals(other);

    public override string ToString()
        => Value.ToString();

    public int CompareTo(object? obj)
        => obj switch
        {
            null => 1,
            Guid guid => CompareTo(guid),
            EntityId entityId => CompareTo(entityId.Value),
            _ => throw new ArgumentException($"Object must be a {nameof(Guid)} or {nameof(EntityId)}.", nameof(obj))
        };

    public string ToString(string? format, IFormatProvider? formatProvider)
        => Value.ToString(format);

    public TypeCode GetTypeCode()
        => TypeCode.Object;

    public bool ToBoolean(IFormatProvider? provider)
        => throw InvalidConversion<bool>();

    public byte ToByte(IFormatProvider? provider)
        => throw InvalidConversion<byte>();

    public char ToChar(IFormatProvider? provider)
        => throw InvalidConversion<char>();

    public DateTime ToDateTime(IFormatProvider? provider)
        => throw InvalidConversion<DateTime>();

    public decimal ToDecimal(IFormatProvider? provider)
        => throw InvalidConversion<decimal>();

    public double ToDouble(IFormatProvider? provider)
        => throw InvalidConversion<double>();

    public short ToInt16(IFormatProvider? provider)
        => throw InvalidConversion<short>();

    public int ToInt32(IFormatProvider? provider)
        => throw InvalidConversion<int>();

    public long ToInt64(IFormatProvider? provider)
        => throw InvalidConversion<long>();

    public sbyte ToSByte(IFormatProvider? provider)
        => throw InvalidConversion<sbyte>();

    public float ToSingle(IFormatProvider? provider)
        => throw InvalidConversion<float>();

    public string ToString(IFormatProvider? provider)
        => Value.ToString();

    public object ToType(Type conversionType, IFormatProvider? provider)
        => conversionType == typeof(Guid)
            ? Value
            : conversionType == typeof(string)
                ? Value.ToString()
                : conversionType == typeof(object)
                    ? this
                    : throw new InvalidCastException(
                        $"Cannot convert {GetType().Name} to {conversionType.Name}.");

    public ushort ToUInt16(IFormatProvider? provider)
        => throw InvalidConversion<ushort>();

    public uint ToUInt32(IFormatProvider? provider)
        => throw InvalidConversion<uint>();

    public ulong ToUInt64(IFormatProvider? provider)
        => throw InvalidConversion<ulong>();

    private InvalidCastException InvalidConversion<T>()
        => new($"Cannot convert {GetType().Name} to {typeof(T).Name}.");
}
