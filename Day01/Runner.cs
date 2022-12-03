using NUnit.Framework;

namespace Day01;

public class Runner
{
    private const string DemoInput = @"1000
2000
3000

4000

5000
6000

7000
8000
9000

10000
";
        
    [Test]
    public void Example_TaskOne()
    {
        var topResult = TaskLogic.CalculateTopElves(DemoInput, 1);

        Assert.AreEqual(24000, topResult);
    }

    [Test]
    public async Task ActualInput_TaskOne()
    {
        var input = await ReadFileContent("input");
        
        Console.WriteLine(TaskLogic.CalculateTopElves(input, 1));
    }
    
    [Test]
    public void Example_TaskTwo()
    {
        var topThree = TaskLogic.CalculateTopElves(DemoInput, 3);

        Assert.AreEqual(45000, topThree);
    }
    
    [Test]
    public async Task ActualInput_TaskTwo()
    {
        var input = await ReadFileContent("input");
        
        Console.WriteLine(TaskLogic.CalculateTopElves(input, 3));
    }

    private static async Task<string> ReadFileContent(string fileName)
    {
        await using var inputFile = new FileStream(fileName, FileMode.Open);
        using var reader = new StreamReader(inputFile);

        return await reader.ReadToEndAsync();
    }
}
