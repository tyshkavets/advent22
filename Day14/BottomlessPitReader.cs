namespace Day14;

public class BottomlessPitReader : ISliceReader
{
    public VerticalSlice GetSlice(IReadOnlyList<Chain> chains)
    {
        var bottomLevel = GetBottomLevel(chains);
        var leftBorder = GetLeftBorder(chains);
        var rightBorder = GetRightBorder(chains);
        var fullWidth = rightBorder - leftBorder + 1;

        return new VerticalSlice(FillMapWithWalls(chains, fullWidth, bottomLevel, leftBorder), leftBorder);
    }
    
    private static bool[][] FillMapWithWalls(IReadOnlyList<Chain> chains, int fullWidth, int bottomLevel, int leftBorder)
    {
        var map = new bool[fullWidth][];

        for (var i = 0; i < fullWidth; i++)
        {
            map[i] = new bool[bottomLevel + 1];
        }

        foreach (var chain in chains)
        {
            for (var i = 0; i < chain.Points.Count - 1; i++)
            {
                var deltaX = Math.Sign(chain.Points[i + 1].X - chain.Points[i].X);
                var deltaY = Math.Sign(chain.Points[i + 1].Y - chain.Points[i].Y);
                var length = Math.Abs(chain.Points[i + 1].X - chain.Points[i].X) + Math.Abs(chain.Points[i + 1].Y - chain.Points[i].Y) + 1;

                var baseX = chain.Points[i].X - leftBorder;
                var baseY = chain.Points[i].Y;
                for (var j = 0; j < length; j++)
                {
                    map[baseX + j * deltaX][baseY + j * deltaY] = true;
                }
            }
        }

        return map;
    }
    
    private static int GetBottomLevel(IReadOnlyList<Chain> chains) => chains.SelectMany(c => c.Points).Select(p => p.Y).Max();

    private static int GetLeftBorder(IReadOnlyList<Chain> chains) => chains.SelectMany(c => c.Points).Select(p => p.X).Min();

    private static int GetRightBorder(IReadOnlyList<Chain> chains) => chains.SelectMany(c => c.Points).Select(p => p.X).Max();
}