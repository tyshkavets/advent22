namespace Day15;

public record SensorData(Point Position, Point ClosestBeacon, int Range)
{
    public static SensorData FromString(string input)
    {
        // Example of expected row:
        // Sensor at x=2, y=18: closest beacon is at x=-2, y=15
        var parsedData = input.Split(new string[] { "Sensor at x=", ", y=", ": closest beacon is at x=" },
            StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        var position = new Point(int.Parse(parsedData[0]), int.Parse(parsedData[1]));
        var beacon = new Point(int.Parse(parsedData[2]), int.Parse(parsedData[3]));

        return new SensorData(position, beacon, Distance.Manhattan(position, beacon));
    }
}