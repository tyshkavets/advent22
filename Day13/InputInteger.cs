namespace Day13;

public class InputInteger : Input
{
    public int Value { get; }

    public InputInteger(int value)
    {
        Value = value;
    }

    public override int GetHashCode() => Value;

    public override string ToString() => Value.ToString();

    public override int CompareTo(Input other)
    {
        return other switch
        {
            InputInteger integer => Math.Sign(Value - integer.Value),
            InputArray array => (-1) * array.CompareTo(this),
            _ => throw new ArgumentOutOfRangeException(nameof(other)),
        };
    }
}
