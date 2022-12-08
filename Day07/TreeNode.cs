namespace Day07;

public class TreeNode
{
    public TreeNode(string name, TreeNode parent)
    {
        Name = name;
        Parent = parent;
        NodeType = TreeNodeType.Directory;
        Children = new List<TreeNode>();
    }

    public TreeNode(string name, TreeNode parent, long size)
    {
        Name = name;
        Parent = parent;
        NodeType = TreeNodeType.File;
        Size = size;
    }
    
    public string Name { get; }
    
    public TreeNode Parent { get; }
    
    public IList<TreeNode> Children { get; }
    
    public TreeNodeType NodeType { get; }
    
    public long Size { get; private set; }

    public void CalculateSizes()
    {
        if (NodeType == TreeNodeType.File)
        {
            return;
        }

        foreach (var child in Children)
        {
            child.CalculateSizes();
        }

        Size = Children.Sum(c => c.Size);
    }

    public IEnumerable<TreeNode> Find(Func<TreeNode, bool> predicate)
    {
        if (NodeType == TreeNodeType.Directory)
        {
            foreach (var child in Children)
            {
                foreach (var treeNode in child.Find(predicate)) yield return treeNode;
            }
        }

        if (predicate(this))
        {
            yield return this;
        }
    }
}
