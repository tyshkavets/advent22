using NUnit.Framework;

namespace Day14;

public class Runner
{
    [Test]
    public void Example_TaskOne()
    {
        Assert.AreEqual(24, Solve_TaskOne("demoInput"));
    }
    
    [Test]
    public void ActualInput_TaskOne()
    {
        Assert.AreEqual(745, Solve_TaskOne("input"));
    }
    
    [Test]
    public void Example_TaskTwo()
    {
        Assert.AreEqual(93, Solve_TaskTwo("demoInput"));
    }
    
    [Test]
    public void ActualInput_TaskTwo()
    {
        Assert.AreEqual(27551, Solve_TaskTwo("input"));
    }
    
    private static int Solve_TaskOne(string fileName) => Solve(fileName, new BottomlessPitReader());
    
    private static int Solve_TaskTwo(string fileName) => Solve(fileName, new InfiniteFloorReader());

    private static int Solve(string fileName, ISliceReader reader) =>
        new GameState(File.ReadAllLines(fileName), reader).Play();
}