using System.Collections.Immutable;

namespace Day13;

public class InputArray : Input
{
    public ImmutableArray<Input> Elements { get; }

    public InputArray(ImmutableArray<Input> elements)
    {
        Elements = elements;
    }

    public override string ToString()
        => $"[{string.Join(",", Elements.Select(e => e.ToString()))}]";
}