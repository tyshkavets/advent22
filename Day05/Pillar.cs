namespace Day05;

public class Pillar
{
    private string _content = string.Empty;

    public void Prepend(char c) => _content = c + _content;

    public void Append(string s) => _content += s;

    public char Top() => _content.Last();
    
    public string CutOff(int c, bool keepOrder = false)
    {
        var last = _content[^c..];
        _content = _content[..^c];

        return keepOrder ? last : new string(last.Reverse().ToArray());
    }
}
