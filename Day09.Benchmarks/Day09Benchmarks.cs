using BenchmarkDotNet.Attributes;

namespace Day09.Benchmarks;

[MemoryDiagnoser()]
public class Day09Benchmarks
{
    private string[] _inputFile = null!;
    
    [Params("demoInput", "largeDemoInput", "input")]
    public string FileName { get; set; }
    
    [Params(2, 10)]
    public int Segments { get; set; }

    [IterationSetup]
    public void IterationSetup() => _inputFile = File.ReadAllLines(FileName);

    [Benchmark(Baseline = true, Description = "Basic stepper")]
    public void RegularStepper()
    {
        var _ = new NaiveSolver(new Stepper()).UniquePositionCounter(_inputFile, Segments);
    }

    [Benchmark(Description = "Caching stepper")]
    public void CachingStepper()
    {
        var _ = new NaiveSolver(new CachingStepper()).UniquePositionCounter(_inputFile, Segments);
    }
}