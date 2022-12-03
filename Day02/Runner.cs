using Day02.GameParsers;
using NUnit.Framework;

namespace Day02;

public class Runner
{
    private const string DemoInput = @"A Y
B X
C Z
";

    [Test]
    public void Example_TaskOne()
    {
        var totalScore = GetTotalScore(DemoInput, new TwoPlayersParser());
        
        Assert.AreEqual(15, totalScore);
    }

    [Test]
    public void Example_TaskTwo()
    {
        var totalScore = GetTotalScore(DemoInput, new OpponentAndOutcomeParser());

        Assert.AreEqual(12, totalScore);
    }
    
    [Test]
    public async Task ActualInput_TaskOne()
    {
        var totalScore = GetTotalScore(await ReadFileContent("input"), new TwoPlayersParser());
        
        Console.WriteLine(totalScore);
    }

    [Test]
    public async Task ActualInput_TaskTwo()
    {
        var totalScore = GetTotalScore(await ReadFileContent("input"), new OpponentAndOutcomeParser());

        Console.WriteLine(totalScore);
    }

    private int GetTotalScore(string input, IGameParser parser)
    {
        var gameLines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        var games = gameLines.Select(parser.Parse);

        return games.Sum(g => g.Score());
    }
    
    private static async Task<string> ReadFileContent(string fileName)
    {
        await using var inputFile = new FileStream(fileName, FileMode.Open);
        using var reader = new StreamReader(inputFile);

        return await reader.ReadToEndAsync();
    }
}
