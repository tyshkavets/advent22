using System.Collections.Immutable;
using NUnit.Framework;

namespace Day13;

public class ParsedInputTests
{
    [Test]
    public void TestParser()
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

    [Test]
    public void Comparison_IsLess_ForShorterArray()
    {
        var first = Build(new[] { 1, 2, 3, 4, 5 });
        var second = Build(new[] { 1, 2, 3, 4, 5, 6 });
        Assert.AreEqual(-1, first.CompareTo(second));
    }
    
    [Test]
    public void Comparison_IsGreater_ForLongerArray()
    {
        var first = Build(new[] { 1, 2, 3, 4, 5, 6, 7 });
        var second = Build(new[] { 1, 2, 3, 4, 5, 6 });
        Assert.AreEqual(1, first.CompareTo(second));
    }
    
    [Test]
    public void Comparison_IsEqual_ForSameArray()
    {
        var first = Build(new[] { 1, 2, 3, 4, 5, 6 });
        var second = Build(new[] { 1, 2, 3, 4, 5, 6 });
        Assert.AreEqual(0, first.CompareTo(second));
    }

    [Test]
    public void IntermediateElement_IsConsidered_ForComparison()
    {
        var first = Build(new[] { 1, 2, 2, 4, 5 });
        var second = Build(new[] { 1, 2, 3, 4, 5 });
        Assert.AreEqual(-1, first.CompareTo(second));
    }

    [Test]
    public void Integer_IsConvertedToArray_WhenNecessary()
    {
        var first = new InputInteger(3);
        var second = Build(new[] { 3 });
        Assert.AreEqual(0, first.CompareTo(second));
    }

    private InputArray Build(int[] arr)
    {
        return new InputArray(arr.Select(x => (Input)(new InputInteger(x))).ToImmutableArray());
    }
}