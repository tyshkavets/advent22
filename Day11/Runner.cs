using NUnit.Framework;

namespace Day11;

public class Runner
{
    [Test]
    public void Example_TaskOne()
    {
        Assert.AreEqual(10605, Solve_TaskOne("demoInput"));
    }
    
    [Test]
    public void ActualInput_TaskOne()
    {
        Assert.AreEqual(99840, Solve_TaskOne("input"));
    }
    
    [Test]
    public void Example_TaskTwo()
    {
        Assert.AreEqual(2713310158, Solve_TaskTwo("demoInput"));
    }
    
    [Test]
    public void ActualInput_TaskTwo()
    {
        Assert.AreEqual(20683044837, Solve_TaskTwo("input"));
    }

    private static long Solve_TaskOne(string fileName) => Solve(fileName, 20, true);

    private static long Solve_TaskTwo(string fileName) => Solve(fileName, 10000, false);

    private static long Solve(string fileName, int iterations, bool calm) =>
        new GameState(File.ReadAllText(fileName)).RunGame(iterations, calm);
}