namespace Day03;

public class TaskOneRucksackSolver : RucksackSolverBase
{
    protected override IEnumerable<string[]> SplitFullInputIntoChunks(string[] input)
        => input.Select(s => new[] { s });

    protected override int GetPriorityOfSingleChunk(string[] chunk)
    {
        var input = chunk[0];
        var firstHalf = input[..(input.Length / 2)];
        var secondHalf = input[(input.Length / 2)..];

        return firstHalf.Intersect(secondHalf).Select(c => c.GetPriority()).Sum();
    }
}
