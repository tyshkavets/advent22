namespace Day08;

public static class NeighbourSolver
{
    public static int CountVisibleTrees(byte[][] matrix)
    {
        var rows = matrix.Length;
        var columns = matrix[0].Length;

        var extraInfo = new CellWithNeighbourInfo[rows][];
        for (var i = 0; i < rows; i++)
        {
            extraInfo[i] = new CellWithNeighbourInfo[columns];
        }

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                extraInfo[i][j] = new CellWithNeighbourInfo();
            }
        }

        for (var i = 0; i < rows; i++)
        {
            extraInfo[i][0].MaxOnLeft = matrix[i][0];
            extraInfo[i][0].VisibleOnLeft = true;
            extraInfo[i][columns - 1].MaxOnRight = matrix[i][columns - 1];
            extraInfo[i][columns - 1].VisibleOnRight = true;
        }

        for (var j = 0; j < columns; j++)
        {
            extraInfo[0][j].MaxOnTop = matrix[0][j];
            extraInfo[0][j].VisibleOnTop = true;
            extraInfo[rows - 1][j].MaxOnBottom = matrix[rows - 1][j];
            extraInfo[rows - 1][j].VisibleOnBottom = true;
        }
        
        // left pass
        for (var i = 0; i < rows; i++)
        {
            for (var j = 1; j < columns; j++)
            {
                var neighbourValue = extraInfo[i][j - 1].MaxOnLeft;
                if (matrix[i][j] > neighbourValue)
                {
                    extraInfo[i][j].VisibleOnLeft = true;
                }
                extraInfo[i][j].MaxOnLeft = Math.Max(neighbourValue, matrix[i][j]);
            }
        }
        
        // right pass
        for (var i = 0; i < rows; i++)
        {
            for (var j = columns - 2; j >= 0; j--)
            {
                var neighbourValue = extraInfo[i][j + 1].MaxOnRight;
                if (matrix[i][j] > neighbourValue)
                {
                    extraInfo[i][j].VisibleOnRight = true;
                }
                extraInfo[i][j].MaxOnRight = Math.Max(neighbourValue, matrix[i][j]);
            }
        }
        
        // top pass
        for (var i = 1; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                var neighbourValue = extraInfo[i - 1][j].MaxOnTop;
                if (matrix[i][j] > neighbourValue)
                {
                    extraInfo[i][j].VisibleOnTop = true;
                }
                extraInfo[i][j].MaxOnTop = Math.Max(neighbourValue, matrix[i][j]);
            }
        }
        
        // bottom pass
        for (var i = rows - 2; i >= 0; i--)
        {
            for (var j = 0; j < columns; j++)
            {
                var neighbourValue = extraInfo[i + 1][j].MaxOnBottom;
                if (matrix[i][j] > neighbourValue)
                {
                    extraInfo[i][j].VisibleOnBottom = true;
                }
                extraInfo[i][j].MaxOnBottom = Math.Max(neighbourValue, matrix[i][j]);
            }
        }

        var counter = 0;

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                var curr = extraInfo[i][j];
                if (curr.VisibleOnLeft || curr.VisibleOnTop || curr.VisibleOnRight || curr.VisibleOnBottom)
                {
                    counter++;
                }
            }
        }

        return counter;
    }

    public class CellWithNeighbourInfo
    {
        public byte MaxOnLeft { get; set; }
        public byte MaxOnRight { get; set; }
        public byte MaxOnTop { get; set; }
        public byte MaxOnBottom { get; set; }
        
        public bool VisibleOnLeft { get; set; }
        public bool VisibleOnRight { get; set; }
        public bool VisibleOnTop { get; set; }
        public bool VisibleOnBottom { get; set; }
    }
}