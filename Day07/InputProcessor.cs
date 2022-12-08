namespace Day07;

public static class InputProcessor
{
    public static TreeNode GetFileSystem(string[] input)
    {
        var shell = new Shell();

        foreach (var line in input)
        {
            shell.ProcessStd(line);
        }

        shell.FileSystemRoot.CalculateSizes();

        return shell.FileSystemRoot;
    }
}
