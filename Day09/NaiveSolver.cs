namespace Day09;

public class NaiveSolver
{
    public static int UniquePositionCounter(IEnumerable<string> instructions, int segmentCount)
    {
        var positions = new HashSet<(int, int)>();

        var segments = new CellPosition[segmentCount];
        for (var i = 0; i < segmentCount; i++)
        {
            segments[i] = new CellPosition(0, 0);
        }

        var stepper = new Stepper();

        foreach (var instruction in instructions)
        {
            var steps = int.Parse(instruction[2..]);

            for (var i = 0; i < steps; i++)
            {
                // Every full chain move is just a number of moves of neighbouring segments executed in the right order
                // So we'll just treat them as a chain of heads and tails so that a tail
                // becomes head in the next sub-step.
                // Real head always gets his movement delta from the directions, the rest of the segments need to
                // override this depending on how much they have to move after their respective head.
                var (moveDeltaX, moveDeltaY) = GetMove(instruction[0]);

                // moving all segments one after another
                for (var j = 0; j < segmentCount - 1; j++)
                {
                    // segments[j] is head
                    // segments[j+1] is tail
                    var previousTail = new CellPosition(segments[j + 1].X, segments[j + 1].Y);
                    (segments[j], segments[j + 1]) =
                        stepper.GetStep(segments[j], segments[j + 1], moveDeltaX, moveDeltaY, j == 0);
                    (moveDeltaX, moveDeltaY) = (segments[j + 1].X - previousTail.X, segments[j + 1].Y - previousTail.Y);
                }
                
                positions.Add((segments[segmentCount - 1].X, segments[segmentCount - 1].Y));
            }
        }
        
        return positions.Count;
    }

    private static (int, int) GetMove(char dir) =>
        dir switch
        {
            'R' => (1, 0),
            'U' => (0, 1),
            'L' => (-1, 0),
            'D' => (0, -1),
            _ => throw new ArgumentOutOfRangeException(nameof(dir), dir, null)
        };
}