namespace Day03;

public abstract class RucksackSolverBase : IRucksackSolver
{
    public int GetPrioritySum(string[] input)
    {
        return SplitFullInputIntoChunks(input)
            .Select(GetPriorityOfSingleChunk)
            .Sum();
    }

    protected abstract IEnumerable<string[]> SplitFullInputIntoChunks(string[] input);

    protected abstract int GetPriorityOfSingleChunk(string[] chunk);
}
