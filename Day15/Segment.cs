namespace Day15;

public record Segment(int Left, int Right)
{
    public int Length => Right - Left + 1;

    public bool Intersect(Segment other) => !(Left > other.Right || Right < other.Left);

    public Segment Merge(Segment other) => new(Math.Min(Left, other.Left), Math.Max(Right, other.Right));
}