using BenchmarkDotNet.Attributes;

namespace Day06.Benchmarks;

[MemoryDiagnoser]
public class Day06Benchmarks
{
    private string _inputFile;
    
    [GlobalSetup]
    public void GlobalSetup() => _inputFile = File.ReadAllText("input");
    
    [Params(4, 14)]
    public int Length { get; set; }

    [Benchmark(Baseline = true, Description = "Naive")]
    public void SolveWithNaiveSolver()
    {
        var _ = NaiveSolver.Solve(_inputFile, Length);
    }
    
    [Benchmark(Description = "Manual check")]
    public void SolveWithNaiveSolverAndManualCheck()
    {
        var _ = NaiveWithManualChecks.Solve(_inputFile, Length);
    }

    [Benchmark(Description = "Via span")]
    public void SolveWithSpanSolver()
    {
        var _ = SpanSolver.Solve(_inputFile, Length);
    }
    
    [Benchmark(Description = "Via span + forward shift")]
    public void SolveWithSpanSolverGen2()
    {
        var _ = SpanSolverGen2.Solve(_inputFile, Length);
    }
}