using NUnit.Framework;

namespace Day13;

public class Runner
{
    [Test]
    public void ParseTester()
    {
        var test = InputParser.Parse("[[3, 4, [5, 6, 7], 8], 9]");
        
        Assert.IsTrue(test.Success);
        
        Assert.IsTrue(test.Value is InputArray);
        
        Assert.AreEqual(2, ((InputArray)test.Value).Elements.Length);

        var secondLevel = ((InputArray)((InputArray)test.Value).Elements[0]).Elements;
        Assert.IsTrue(secondLevel[0] is InputInteger);
        Assert.IsTrue(secondLevel[1] is InputInteger);
        Assert.IsTrue(secondLevel[2] is InputArray);
        Assert.IsTrue(secondLevel[3] is InputInteger);
        
        Assert.AreEqual(8, ((InputInteger)secondLevel[3]).Value);
    }
}