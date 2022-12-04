namespace Day04;

public record Range(int Left, int Right)
{
    public static Range FromString(string input)
    {
        var parts = input.Split('-').Select(int.Parse).ToList();

        return new Range(parts[0], parts[1]);
    }

    public bool ContainsOrIsContainedIn(Range another) => Contains(another) || another.Contains(this);

    public bool Overlaps(Range another) => !(Left > another.Right || Right < another.Left);

    private bool Contains(Range another) => Left <= another.Left && Right >= another.Right;
}
