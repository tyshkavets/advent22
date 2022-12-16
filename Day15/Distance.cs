namespace Day15;

public static class Distance
{
    public static int Manhattan(Point a, Point b) => Math.Abs(b.X - a.X) + Math.Abs(b.Y - a.Y);
}