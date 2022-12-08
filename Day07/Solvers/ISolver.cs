namespace Day07.Solvers;

public interface ISolver
{
    Func<TreeNode, bool> GetFilterPredicate(TreeNode root);
    
    Func<IEnumerable<TreeNode>, long> Aggregate { get; }
}
