using NUnit.Framework;

namespace Day15;

public class Runner
{
    [Test]
    public void Example_TaskOne()
    {
        var state = new GameState(File.ReadAllLines("demoInput")).TaskOne(10);
        
        Assert.AreEqual(26, state);
    }
    
    [Test]
    public void ActualInput_TaskOne()
    {
        var state = new GameState(File.ReadAllLines("input")).TaskOne(2000000);
        
        Assert.AreEqual(4725497, state);
    }
    
    [Test]
    public void Example_TaskTwo()
    {
        var state = new GameState(File.ReadAllLines("demoInput")).TaskTwo_Bruteforce();
        
        Assert.AreEqual(56000011, state);
    }
    
    [Test]
    public void ActualInput_TaskTwo()
    {
        var state = new GameState(File.ReadAllLines("input")).TaskTwo_Bruteforce();
        
        Assert.AreEqual(12051287042458, state);
    }
}