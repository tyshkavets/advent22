namespace Day07.Solvers;

public class TaskTwoSolver : ISolver
{
    private const int DiskSize = 70_000_000;
    private const int UpdateSize = 30_000_000;
    
    public Func<TreeNode, bool> GetFilterPredicate(TreeNode root)
    {
        var empty = DiskSize - root.Size;
        var toCleanup = UpdateSize - empty;

        return t => t.NodeType == TreeNodeType.Directory && t.Size >= toCleanup;
    }

    public Func<IEnumerable<TreeNode>, long> Aggregate => nodes => nodes.OrderBy(t => t.Size).First().Size;
}
