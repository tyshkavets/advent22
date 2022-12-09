using NUnit.Framework;

namespace Day09;

public class Runner
{
    [Test]
    public void Example_TaskOne() => Assert.AreEqual(13, Solve_TaskOne("demoInput"));
    
    [Test]
    public void ActualInput_TaskOne() => Assert.AreEqual(6037, Solve_TaskOne("input"));
    
    [Test]
    public void Example_TaskTwo() => Assert.AreEqual(1, Solve_TaskTwo("demoInput"));

    [Test]
    public void LargerExample_TaskTwo() => Assert.AreEqual(36, Solve_TaskTwo("largeDemoInput"));
    
    [Test]
    public void ActualInput_TaskTwo() => Assert.AreEqual(2485, Solve_TaskTwo("input"));

    private int Solve_TaskOne(string fileName) => Solve(fileName, 2);

    private int Solve_TaskTwo(string fileName) => Solve(fileName, 10);

    private int Solve(string fileName, int segments) =>
        NaiveSolver.UniquePositionCounter(File.ReadAllLines(fileName), segments);
}