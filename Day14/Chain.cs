namespace Day14;

public record Chain(IReadOnlyList<(int X, int Y)> Points)
{
    public static Chain Parse(string inputLine)
    {
        var pointStrings = inputLine.Split(" -> ");
        var list = new List<(int X, int Y)>();

        foreach (var pointString in pointStrings)
        {
            var indexOf = pointString.IndexOf(',');
            list.Add((int.Parse(pointString[..indexOf]), int.Parse(pointString[(indexOf + 1)..])));
        }

        return new Chain(list);
    }
}