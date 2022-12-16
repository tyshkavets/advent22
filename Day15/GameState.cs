namespace Day15;

public class GameState
{
    private IReadOnlyList<SensorData> _sensors;
    
    public GameState(string[] input)
    {
        _sensors = input.Select(SensorData.FromString).ToList();
    }

    public int TaskOne(int y)
    {
        var segments = new List<Segment>();

        foreach (var sensor in _sensors)
        {
            if (Math.Abs(sensor.Position.Y - y) <= sensor.Range)
            {
                var width = sensor.Range - Math.Abs(sensor.Position.Y - y);
                segments.Add(new Segment(sensor.Position.X - width, sensor.Position.X + width));
            }
        }

        segments = IntersectAllSegments(segments);

        return segments.Sum(s => s.Length) -
               _sensors.Where(s => s.ClosestBeacon.Y == 10).Select(s => s.ClosestBeacon.X).Distinct().Count();
    }

    public long TaskTwo_Bruteforce()
    {
        for (var y = 0; y < 4_000_000; y++)
        {
            var res = Check(y);

            if (res.HasValue)
            {
                Console.WriteLine($"Result y: {y}, found position {res.Value}");

                return res.Value * 4_000_000L + y;
            }
        }

        throw new Exception();
        
        int? Check(int y)
        {
            var segments = new List<Segment>();

            foreach (var sensor in _sensors)
            {
                if (Math.Abs(sensor.Position.Y - y) <= sensor.Range)
                {
                    var width = sensor.Range - Math.Abs(sensor.Position.Y - y);
                    segments.Add(new Segment(sensor.Position.X - width, sensor.Position.X + width));
                }
            }

            segments = IntersectAllSegments(segments);

            if (segments.Count > 0)
            {
                for (int i = 0; i < segments.Count - 1; i++)
                {
                    if (segments[i + 1].Left - segments[i].Right == 2)
                    {
                        return segments[i].Right + 1;
                    }
                }
            }

            if (y % 10000 == 0)
            {
                Console.WriteLine(y);
            }

            return null;
        }
    }

    private static List<Segment> IntersectAllSegments(List<Segment> segments)
    {
        segments = segments.OrderBy(c => c.Left).ToList();
        for (var i = 0; i < segments.Count; i++)
        {
            var currentSegment = segments[i];

            var toIntersectQueue = new Queue<Segment>();
            var removalQueue = new List<int>();
            for (var j = i+1; j < segments.Count; j++)
            {
                if (currentSegment.Intersect(segments[j]))
                {
                    removalQueue.Insert(0, j);
                    toIntersectQueue.Enqueue(segments[j]);
                }
            }

            var hasIntersections = removalQueue.Any();

            foreach (var indexToRemove in removalQueue)
            {
                segments.RemoveAt(indexToRemove);
            }

            var nextSegment = new Segment(currentSegment.Left, currentSegment.Right);
            while (toIntersectQueue.TryDequeue(out var segment))
            {
                nextSegment = nextSegment.Merge(segment);
            }

            segments[i] = nextSegment;

            if (hasIntersections)
            {
                i--;
            }
        }

        return segments;
    }
}