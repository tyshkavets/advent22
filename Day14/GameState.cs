namespace Day14;

public class GameState
{
    public const int StartPositionX = 500;
    public const int StartPositionY = 0;

    private readonly int _bottomLevel;
    private readonly int _leftBorder;
    private readonly int _rightBorder;

    private readonly bool[][] _map;
    private int _counter; 
    
    public GameState(ICollection<string> input, ISliceReader sliceReader)
    {
        IReadOnlyList<Chain> chains = input.Select(Chain.Parse).ToList();

        var result = sliceReader.GetSlice(chains);
        _map = result.Map;
        _leftBorder = result.XOffset;
        _rightBorder = result.XOffset + _map.Length - 1;
        _bottomLevel = result.Map[0].Length - 1;
    }

    public int Play()
    {
        while (true)
        {
            var res = NextSandBlock();

            if (res == null)
            {
                return _counter;
            }

            if (res.Value.X == StartPositionX && res.Value.Y == StartPositionY)
            {
                return _counter + 1;
            }

            _counter++;
            _map[res.Value.X - _leftBorder][res.Value.Y] = true;
        }
    }
    
    private (int X, int Y)? NextSandBlock(int startX = StartPositionX, int startY = StartPositionY)
    {
        if (startY == _bottomLevel)
        {
            return null;
        }
        
        if (!_map[startX - _leftBorder][startY + 1])
        {
            return NextSandBlock(startX, startY + 1);
        }

        if (startX - _leftBorder == 0)
        {
            return null;
        }

        if (!_map[startX - _leftBorder - 1][startY + 1])
        {
            return NextSandBlock(startX - 1, startY + 1);
        }

        if (startX == _rightBorder)
        {
            return null;
        }

        if (!_map[startX - _leftBorder + 1][startY + 1])
        {
            return NextSandBlock(startX + 1, startY + 1);
        }

        return (startX, startY);
    }
}