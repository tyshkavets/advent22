namespace Day08;

public class CardinalDirection
{
    public int Dx { get; }
    public int Dy { get; }

    private CardinalDirection(int dx, int dy) => (Dx, Dy) = (dx, dy);

    public static CardinalDirection Left { get; } = new(0, -1);

    public static CardinalDirection Top { get; } = new(-1, 0);

    public static CardinalDirection Right { get; } = new(0, 1);

    public static CardinalDirection Bottom { get; } = new(1, 0);

    public static IEnumerable<CardinalDirection> AllDirections { get; } = new[] { Left, Top, Right, Bottom };
}    
