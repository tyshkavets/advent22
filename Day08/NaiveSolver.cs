namespace Day08;

public static class NaiveSolver
{
    public static int CountVisibleTrees(byte[][] matrix)
    {
        var solver = new Solver<bool>(false, (acc, curr) => acc || curr, x => x.Count(r => r), true,
            (actual, current, _) => current < actual);

        return solver.Solve(matrix);
    }

    public static int CountScenicScore(byte[][] matrix)
    {
        var solver = new Solver<int>(1, (acc, curr) => acc * curr, l => l.Max(), 0, (_, _, acc) => acc + 1);

        return solver.Solve(matrix);
    }
}
