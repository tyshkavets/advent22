namespace Day14;

public class InfiniteFloorReader : ISliceReader
{
    private readonly ISliceReader _underlyingReader;

    public InfiniteFloorReader()
    {
        _underlyingReader = new BottomlessPitReader();
    }
    
    public VerticalSlice GetSlice(IReadOnlyList<Chain> chains)
    {
        var originalResult = _underlyingReader.GetSlice(chains);

        var originalHeight = originalResult.Map[0].Length;
        var neededHeight = originalHeight + 2;
        var fullWidth = neededHeight * 2 + 1;

        var realOffset = GameState.StartPositionX - neededHeight;
        
        var map = new bool[fullWidth][];

        for (var i = 0; i < fullWidth; i++)
        {
            map[i] = new bool[neededHeight];
        }

        // copy old map with a small shift
        var offsetOffset = originalResult.XOffset - realOffset;
        for (var i = 0; i < originalResult.Map.Length; i++)
        {
            for (var j = 0; j < originalResult.Map[i].Length; j++)
            {
                map[i + offsetOffset][j] = originalResult.Map[i][j];
            }
        }

        // add floor
        for (var i = 0; i < fullWidth; i++)
        {
            map[i][neededHeight - 1] = true;
        }

        return new VerticalSlice(map, realOffset);
    }
}