namespace Day13;

public class InputInteger : Input
{
    public int Value { get; }

    public InputInteger(int value)
    {
        Value = value;
    }

    public override int GetHashCode() => Value;
}