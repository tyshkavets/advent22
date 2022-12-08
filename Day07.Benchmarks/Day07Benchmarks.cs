using BenchmarkDotNet.Attributes;
using Day07.Solvers;

namespace Day07;

[MemoryDiagnoser]
public class Day07Benchmarks
{
    private string[] _inputFile = null!;
    
    [Params("demoInput", "input")]
    public string FileName { get; set; }
    
    [IterationSetup]
    public void IterationSetup() => _inputFile = File.ReadAllLines(FileName);

    [Benchmark(Baseline = true, Description = "Base solution")]
    public void TaskTwo_BaseSolver()
    {
        var solver = new TaskTwoSolver();
        var root = InputProcessor.GetFileSystem(_inputFile);

        var result = solver.Aggregate(root.Find(t => solver.GetFilterPredicate(root)(t)));
    }

    [Benchmark(Description = "Improved aggregation")]
    public void TaskTwo_ImprovedAggregate()
    {
        var solver = new TaskTwoSolverWithBetterAgg();
        var root = InputProcessor.GetFileSystem(_inputFile);

        var result = solver.Aggregate(root.Find(t => solver.GetFilterPredicate(root)(t)));
    }
}