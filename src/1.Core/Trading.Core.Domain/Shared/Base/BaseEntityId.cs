namespace Trading.Core.Domain.Shared.Base;

public readonly record struct BaseEntityId(long Value)
    : IComparable,
      IComparable<BaseEntityId>,
      IConvertible,
      IEquatable<BaseEntityId>,
      IFormattable
{
    public static BaseEntityId New()
        => new(SnowflakeIdGenerator.Instance.Next());

    public override string ToString()
        => Value.ToString();

    public string ToString(string? format, IFormatProvider? formatProvider)
        => Value.ToString(format, formatProvider);

    public int CompareTo(object? obj)
        => obj is BaseEntityId other ? CompareTo(other) : 1;

    public int CompareTo(BaseEntityId other)
        => Value.CompareTo(other.Value);

    public bool Equals(BaseEntityId other)
        => Value == other.Value;

    public override int GetHashCode()
        => Value.GetHashCode();

    public static implicit operator long(BaseEntityId id)
        => id.Value;

    public static implicit operator BaseEntityId(long value)
        => new(value);

    public TypeCode GetTypeCode() => TypeCode.Int64;
    public bool ToBoolean(IFormatProvider? provider) => Convert.ToBoolean(Value, provider);
    public byte ToByte(IFormatProvider? provider) => Convert.ToByte(Value, provider);
    public char ToChar(IFormatProvider? provider) => Convert.ToChar(Value, provider);
    public DateTime ToDateTime(IFormatProvider? provider) => Convert.ToDateTime(Value, provider);
    public decimal ToDecimal(IFormatProvider? provider) => Convert.ToDecimal(Value, provider);
    public double ToDouble(IFormatProvider? provider) => Convert.ToDouble(Value, provider);
    public short ToInt16(IFormatProvider? provider) => Convert.ToInt16(Value, provider);
    public int ToInt32(IFormatProvider? provider) => Convert.ToInt32(Value, provider);
    public long ToInt64(IFormatProvider? provider) => Value;
    public sbyte ToSByte(IFormatProvider? provider) => Convert.ToSByte(Value, provider);
    public float ToSingle(IFormatProvider? provider) => Convert.ToSingle(Value, provider);
    public string ToString(IFormatProvider? provider) => Value.ToString(provider);
    public object ToType(Type conversionType, IFormatProvider? provider)
        => Convert.ChangeType(Value, conversionType, provider)!;
    public ushort ToUInt16(IFormatProvider? provider) => Convert.ToUInt16(Value, provider);
    public uint ToUInt32(IFormatProvider? provider) => Convert.ToUInt32(Value, provider);
    public ulong ToUInt64(IFormatProvider? provider) => Convert.ToUInt64(Value, provider);
}




public sealed class SnowflakeIdGenerator
{
    public static SnowflakeIdGenerator Instance { get; } = new(1);

    private readonly long _workerId;

    private const long Epoch = 1735689600000L; // 2025-01-01 UTC

    private const int WorkerIdBits = 10;
    private const int SequenceBits = 12;

    private const long MaxSequence = (1L << SequenceBits) - 1;

    private const int WorkerShift = SequenceBits;
    private const int TimestampShift = WorkerIdBits + SequenceBits;

    private long _lastTimestamp = -1;
    private long _sequence;

    private readonly Lock _lock = new();

    public SnowflakeIdGenerator(long workerId)
    {
        _workerId = workerId;
    }

    public long Next()
    {
        lock (_lock)
        {
            var timestamp = CurrentTimestamp();

            if (timestamp < _lastTimestamp)
                throw new InvalidOperationException("Clock moved backwards.");

            if (timestamp == _lastTimestamp)
            {
                _sequence = (_sequence + 1) & MaxSequence;

                if (_sequence == 0)
                    timestamp = WaitNext(_lastTimestamp);
            }
            else
            {
                _sequence = 0;
            }

            _lastTimestamp = timestamp;

            return ((timestamp - Epoch) << TimestampShift)
                   | (_workerId << WorkerShift)
                   | _sequence;
        }
    }

    private static long CurrentTimestamp()
        => DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

    private static long WaitNext(long last)
    {
        var ts = CurrentTimestamp();

        while (ts <= last)
            ts = CurrentTimestamp();

        return ts;
    }
}