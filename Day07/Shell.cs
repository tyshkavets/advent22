namespace Day07;

public class Shell
{
    public readonly TreeNode FileSystemRoot;

    private TreeNode _current;

    public Shell()
    {
        FileSystemRoot = new TreeNode("/", default!);
        _current = FileSystemRoot;
    }

    private void GoToRoot() => _current = FileSystemRoot;

    private void GoUp() => _current = _current.Parent;

    private void GoToChild(string line) => _current = _current.Children.First(c => c.Name == line[5..]);

    private void SaveDir(string line) => _current.Children.Add(new TreeNode(line[4..], _current));

    private void SaveFile(string line)
    {
        var lineParts = line.Split(' ');
        
        _current.Children.Add(new TreeNode(lineParts[1], _current, long.Parse(lineParts[0])));
    }

    public void ProcessStd(string line)
    {
        switch (line)
        {
            case "$ cd /":
                GoToRoot();
                break;
            case "$ cd ..":
                GoUp();
                break;
            case { } when line.StartsWith("$ cd"):
                GoToChild(line);
                break;
            case { } when line.StartsWith("dir"):
                SaveDir(line);
                break;
            case { } when line[0] >= '0' && line[0] <= '9':
                SaveFile(line);
                break;
        }
    }
}
