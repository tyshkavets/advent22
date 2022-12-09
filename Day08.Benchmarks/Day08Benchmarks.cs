using BenchmarkDotNet.Attributes;

namespace Day08.Benchmarks;

[MemoryDiagnoser]
public class Day08Benchmarks
{
    private byte[][] _inputFile = null!;
    
    [Params("demoInput", "input")]
    public string FileName { get; set; }

    [IterationSetup]
    public void IterationSetup() => _inputFile = ReadFromFile(FileName);

    [Benchmark(Baseline = true, Description = "Base solution")]
    public void TaskTwo_BaseSolver()
    {
        var _ = NaiveSolver.CountVisibleTrees(_inputFile);
    }

    [Benchmark(Description = "Improved quadratic algo")]
    public void TaskTwo_ImprovedAggregate()
    {
        var _ = NeighbourSolver.CountVisibleTrees(_inputFile);
    }
    
    private static byte[][] ReadFromFile(string inputFileName)
    {
        var lines = File.ReadAllLines(inputFileName);

        return lines
            .Select(t => t.Select(c => (byte)(c - '0')).ToArray())
            .ToArray();
    }
}