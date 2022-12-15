using NUnit.Framework;

namespace Day13;

public class Runner
{
    [Test]
    public void Example_TaskOne() => Assert.AreEqual(13, Solve_TaskOne("demoInput"));

    [Test]
    public void ActualInput_TaskOne() => Assert.AreEqual(6484, Solve_TaskOne("input"));
    
    [Test]
    public void Example_TaskTwo() => Assert.AreEqual(140, Solve_TaskTwo("demoInput"));
    
    [Test]
    public void ActualInput_TaskTwo() => Assert.AreEqual(19305, Solve_TaskTwo("input"));

    private static int Solve_TaskOne(string fileName)
    {
        var lines = File.ReadAllLines(fileName);
        var pairCount = (lines.Length + 1) / 3;

        var sum = 0;
        
        for (var i = 1; i <= pairCount; i++)
        {
            var first = InputParser.Parse(lines[3 * (i - 1)]);
            var second = InputParser.Parse(lines[3 * (i - 1) + 1]);

            if (first.Value.CompareTo(second.Value) <= 0)
            {
                sum += i;
            }
        }

        return sum;
    }

    private static int Solve_TaskTwo(string fileName)
    {
        var sortInput = new List<Input>();
        
        var lines = File.ReadAllLines(fileName);
        var pairCount = (lines.Length + 1) / 3;

        var sum = 0;
        
        for (var i = 1; i <= pairCount; i++)
        {
            sortInput.Add(InputParser.Parse(lines[3 * (i - 1)]).Value);
            sortInput.Add(InputParser.Parse(lines[3 * (i - 1) + 1]).Value);
        }

        var twoDivider = InputParser.Parse("[[2]]").Value;
        var sixDivider = InputParser.Parse("[[6]]").Value;
        
        sortInput.Add(twoDivider);
        sortInput.Add(sixDivider);

        sortInput.Sort(Comparison);
        var twoIndex = sortInput.FindIndex(i => i.ToString() == "[[2]]") + 1;
        var sixIndex = sortInput.FindIndex(i => i.ToString() == "[[6]]") + 1;

        return twoIndex * sixIndex;
    }

    private static int Comparison(Input x, Input y)
    {
        return x.CompareTo(y);
    }
}