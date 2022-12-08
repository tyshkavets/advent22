using Day07.Solvers;
using NUnit.Framework;

namespace Day07;

public class Runner
{
    [Test]
    public void Example_TaskOne() => Assert.AreEqual(95437, Solve("demoInput", new TaskOneSolver()));

    [Test]
    public void ActualInput_TaskOne() => Assert.AreEqual(1423358, Solve("input", new TaskOneSolver()));

    [Test]
    public void Example_TaskTwo() => Assert.AreEqual(24933642, Solve("demoInput", new TaskTwoSolver()));

    [Test]
    public void ActualInput_TaskTwo() => Assert.AreEqual(545729, Solve("input", new TaskTwoSolver()));
    
    private static long Solve(string inputFileName, ISolver solver)
    {
        var root = InputProcessor.GetFileSystem(inputFileName);

        return solver.Aggregate(root.Find(t => solver.GetFilterPredicate(root)(t)));
    }
}
