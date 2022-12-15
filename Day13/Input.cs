using System.Diagnostics.CodeAnalysis;

namespace Day13;

[SuppressMessage("naming", "CA1724:The type name conflicts with the namespace name", Justification = "Example code")]
public abstract class Input
{
    public abstract int CompareTo(Input other);
}