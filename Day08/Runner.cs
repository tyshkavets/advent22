using NUnit.Framework;

namespace Day08;

public class Runner
{
    [Test]
    public void Example_TaskOne() => Assert.AreEqual(21, Solve_TaskOne("demoInput"));

    [Test]
    public void ActualInput_TaskOne() => Assert.AreEqual(1733, Solve_TaskOne("input"));

    [Test]
    public void Example_TaskTwo() => Assert.AreEqual(8, Solve_TaskTwo("demoInput"));

    [Test]
    public void ActualInput_TaskTwo() => Assert.AreEqual(284648, Solve_TaskTwo("input"));

    private static int Solve_TaskOne(string fileName) => Solve(fileName, NaiveSolver.CountVisibleTrees);

    private static int Solve_TaskTwo(string fileName) => Solve(fileName, NaiveSolver.CountScenicScore);

    private static int Solve(string fileName, Func<byte[][], int> fileSolver) => fileSolver(ReadFromFile(fileName));

    private static byte[][] ReadFromFile(string inputFileName)
    {
        var lines = File.ReadAllLines(inputFileName);

        return lines
            .Select(t => t.Select(c => (byte)(c - '0')).ToArray())
            .ToArray();
    }
}
