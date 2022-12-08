namespace Day07.Solvers;

public class TaskOneSolver : ISolver
{
    private const int TaskOneLimit = 100_000;
    
    public Func<TreeNode, bool> GetFilterPredicate(TreeNode root) => directory =>
        directory.NodeType == TreeNodeType.Directory && directory.Size <= TaskOneLimit;

    public Func<IEnumerable<TreeNode>, long> Aggregate => nodes => nodes.Sum(e => e.Size);
}
