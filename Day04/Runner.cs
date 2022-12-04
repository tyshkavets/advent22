using NUnit.Framework;

namespace Day04;

public class Runner
{
    private static readonly string[] DemoInput =
    {
        "2-4,6-8",
        "2-3,4-5",
        "5-7,7-9",
        "2-8,3-7",
        "6-6,4-6",
        "2-6,4-8",
    };
    
    [Test]
    public void Example_TaskOne() => Assert.AreEqual(2, Solve(DemoInput, TaskOneSpecification));
    
    [Test]
    public void Example_TaskTwo() => Assert.AreEqual(4, Solve(DemoInput, TaskTwoSpecification));
    
    [Test]
    public void ActualInput_TaskOne() =>
        Console.WriteLine(Solve(ReadFileContent("input"), TaskOneSpecification));
    
    [Test]
    public void ActualInput_TaskTwo() =>
        Console.WriteLine(Solve(ReadFileContent("input"), TaskTwoSpecification));

    private static int Solve(IEnumerable<string> input, Func<Range, Range, bool> predicate)
    {
        return input
            .Select(s => s
                .Split(',')
                .Select(Range.FromString)
                .ToArray())
            .Count(pair => predicate(pair[0], pair[1]));
    }

    private static bool TaskOneSpecification(Range first, Range second) => first.ContainsOrIsContainedIn(second);

    private static bool TaskTwoSpecification(Range first, Range second) => first.Overlaps(second);

    private static IEnumerable<string> ReadFileContent(string fileName) => File.ReadAllLines(fileName);
}
