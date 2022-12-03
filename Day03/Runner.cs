using NUnit.Framework;

namespace Day03;

public class Runner
{
    private static readonly string[] DemoInput =
    {
        "vJrwpWtwJgWrhcsFMMfFFhFp",
        "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
        "PmmdzqPrVvPwwTWBwg",
        "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
        "ttgJtRGJQctTZtZT",
        "CrZsJsPPZsGzwwsLwLmpwMDw",
    };

    [Test]
    public void Example_TaskOne() => Assert.AreEqual(157, Solve(new TaskOneRucksackSolver(), DemoInput));

    [Test]
    public void Example_TaskTwo() => Assert.AreEqual(70, Solve(new TaskTwoRucksackSolver(), DemoInput));

    [Test]
    public void ActualInput_TaskOne() =>
        Console.WriteLine(Solve(new TaskOneRucksackSolver(), ReadFileContent("input")));

    [Test]
    public void ActualInput_TaskTwo() =>
        Console.WriteLine(Solve(new TaskTwoRucksackSolver(), ReadFileContent("input")));

    private static int Solve(IRucksackSolver solver, string[] input) => solver.GetPrioritySum(input);

    private static string[] ReadFileContent(string fileName) => File.ReadAllLines(fileName);
}
