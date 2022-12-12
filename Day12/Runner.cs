using NUnit.Framework;

namespace Day12;

public class Runner
{
    [Test]
    public void Example_TaskOne() => Assert.AreEqual(31, Solve_TaskOne("demoInput"));

    [Test]
    public void ActualInput_TaskOne() => Assert.AreEqual(361, Solve_TaskOne("input"));

    [Test]
    public void Example_TaskTwo() => Assert.AreEqual(29, Solve_TaskTwo("demoInput"));

    [Test]
    public void ActualInput_TaskTwo() => Assert.AreEqual(354, Solve_TaskTwo("input"));

    private static int Solve_TaskOne(string fileName) => new Field(File.ReadAllLines(fileName)).FindPath();

    private static int Solve_TaskTwo(string fileName) => new Field(File.ReadAllLines(fileName)).FindScenicRoute();
}