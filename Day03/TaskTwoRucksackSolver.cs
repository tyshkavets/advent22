namespace Day03;

public class TaskTwoRucksackSolver : RucksackSolverBase
{
    protected override IEnumerable<string[]> SplitFullInputIntoChunks(string[] input) => input.Chunk(3);

    protected override int GetPriorityOfSingleChunk(string[] chunk)
        => chunk[0].Intersect(chunk[1]).Intersect(chunk[2]).Select(c => c.GetPriority()).Sum();
}
