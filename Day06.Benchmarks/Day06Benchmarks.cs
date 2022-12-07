using BenchmarkDotNet.Attributes;

namespace Day06.Benchmarks;

[MemoryDiagnoser]
public class Day06Benchmarks
{
    
    
    [Benchmark(Baseline = true, Description = "With 4 length")]
    public void SolveShortWithNaiveSolver()
    {
        var _ = NaiveSolver.Solve(File.ReadAllText("input"), 4);
    }
    
    [Benchmark(Description = "With 4 length and manual check")]
    public void SolveShortWithNaiveSolverAndManualCheck()
    {
        var _ = NaiveWithManualChecks.Solve(File.ReadAllText("input"), 4);
    }

    [Benchmark(Description = "With 4 length via span")]
    public void SolveShortWithSpanSolver()
    {
        var _ = SpanSolver.Solve(File.ReadAllText("input"), 4);
    }
    
    [Benchmark(Description = "With 14 length")]
    public void SolveLongWithNaiveSolver()
    {
        var _ = NaiveSolver.Solve(File.ReadAllText("input"), 14);
    }
    
    [Benchmark(Description = "With 14 length and manual check")]
    public void SolveLongWithNaiveSolverAndManualCheck()
    {
        var _ = NaiveWithManualChecks.Solve(File.ReadAllText("input"), 14);
    }
    
    [Benchmark(Description = "With 14 length via span")]
    public void SolveLongWithSpanSolver()
    {
        var _ = SpanSolver.Solve(File.ReadAllText("input"), 14);
    }
}