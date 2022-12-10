using NUnit.Framework;

namespace Day10;

public class Runner
{
    [Test]
    public void Example_TaskOne()
    {
        Assert.AreEqual(13140, SolveSystem("demoInput"));
    }

    [Test]
    public void Example_TaskTwo()
    {
        RenderScreen("demoInput");
    }

    [Test]
    public void ActualInput_TaskOne()
    {
        Assert.AreEqual(11720, SolveSystem("input"));
    }
    
    [Test]
    public void ActualInput_TaskTwo()
    {
        RenderScreen("input");
    }

    private static int SolveSystem(string fileName)
    {
        var system = new System(File.ReadAllLines(fileName));

        system.Process();

        return system.SignalMeter.Accumulator;
    }

    private static void RenderScreen(string fileName)
    {
        var system = new System(File.ReadAllLines(fileName));

        system.Process();

        for (var i = 0; i < 6; i++)
        {
            for (var j = 0; j < 40; j++)
            {
                var coord = i * 40 + j;
                Console.Write(system.Screen.screen[coord] ? '#' : '.');
            }
            Console.WriteLine();
        }
    }
}