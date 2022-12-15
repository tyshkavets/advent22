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

    public override int CompareTo(Input other)
    {
        return other switch
        {
            InputArray inputArray => CompareToArray(inputArray),
            InputInteger inputInteger => CompareTo(new InputArray(new Input[] { inputInteger }.ToImmutableArray())),
            _ => throw new ArgumentOutOfRangeException(nameof(other))
        };
    }

    private int CompareToArray(InputArray inputArray)
    {
        for (var i = 0; i < Elements.Length; i++)
        {
            var currElement = Elements[i];

            if (inputArray.Elements.Length <= i)
            {
                return 1;
            }

            var correspondingElement = inputArray.Elements[i];

            var comparison = currElement.CompareTo(correspondingElement);

            if (comparison != 0)
            {
                return comparison;
            }
        }

        if (inputArray.Elements.Length > Elements.Length)
        {
            return -1;
        }

        return 0;
    }
}