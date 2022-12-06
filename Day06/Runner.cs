using NUnit.Framework;

namespace Day06;

public class Runner
{
    [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
    [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
    [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 6)]
    [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
    [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
    public void Example_TaskOne(string input, int output)
    {
        Assert.AreEqual(output, Solve(input, 4));
    }
    
    [Test]
    public void ActualInput_TaskOne()
    {
        Assert.AreEqual(1702, Solve(File.ReadAllText("input"), 4));
    }
    
    [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
    [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
    [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 23)]
    [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
    [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
    public void Example_TaskTwo(string input, int output)
    {
        Assert.AreEqual(output, Solve(input, 14));
    }
    
    [Test]
    public void ActualInput_TaskTwo()
    {
        Assert.AreEqual(3559, Solve(File.ReadAllText("input"), 14));
    }

    private static int Solve(string input, int length)
    {
        for (var i = length - 1; i < input.Length; i++)
        {
            var testMarker = input.Substring(i - length + 1, length);

            if (testMarker.Distinct().Count() == length)
            {
                return i + 1;
            }
        }

        throw new Exception();
    }
}