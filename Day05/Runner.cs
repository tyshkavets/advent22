using NUnit.Framework;

namespace Day05;

public class Runner
{
    private const string DemoInput = @"    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2";

    [Test]
    public void Example_TaskOne()
    {
        var result = Solve(DemoInput);
        
        Assert.AreEqual("CMZ", result);
    }

    [Test]
    public async Task ActualInput_TaskOne()
    {
        var input = await ReadFileContent("input");
        
        Console.WriteLine(Solve(input));
    }
    
    [Test]
    public void Example_TaskTwo()
    {
        var result = Solve(DemoInput, true);
        
        Assert.AreEqual("MCD", result);
    }

    [Test]
    public async Task ActualInput_TaskTwo()
    {
        var input = await ReadFileContent("input");
        
        Console.WriteLine(Solve(input, true));
    }

    public string Solve(string fullInput, bool keepOrder = false)
    {
        var parser = new InputParser();
        var game = parser.Parse(fullInput);

        foreach (var gameMove in game.Moves)
        {
            game.GameState.ApplyMove(gameMove, keepOrder);
        }

        return game.GameState.ReturnTop();
    }

    private static async Task<string> ReadFileContent(string fileName)
    {
        await using var inputFile = new FileStream(fileName, FileMode.Open);
        using var reader = new StreamReader(inputFile);

        return await reader.ReadToEndAsync();
    }
}
