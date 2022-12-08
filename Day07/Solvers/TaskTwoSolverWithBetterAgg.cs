namespace Day07.Solvers;

public class TaskTwoSolverWithBetterAgg : ISolver
{
    private const int DiskSize = 70_000_000;
    private const int UpdateSize = 30_000_000;

    public Func<TreeNode, bool> GetFilterPredicate(TreeNode root)
    {
        var empty = DiskSize - root.Size;
        var toCleanup = UpdateSize - empty;

        return t => t.NodeType == TreeNodeType.Directory && t.Size >= toCleanup;
    }

    public Func<IEnumerable<TreeNode>, long> Aggregate => nodes => nodes.Select(t => t.Size).Min();
}