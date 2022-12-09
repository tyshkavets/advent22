namespace Day08;

public class SingleItemCalculator<T>
{
    private readonly T _seed;
    private readonly Func<byte, byte, T, T> _aggregation;

    public SingleItemCalculator(T seed, Func<byte, byte, T, T> aggregation)
    {
        _seed = seed;
        _aggregation = aggregation;
    }

    public T Solve(byte[][] matrix, int currX, int currY, CardinalDirection direction)
    {
        var rows = matrix.Length;
        var columns = matrix[0].Length;
        var actualValue = matrix[currX][currY];
        var baseValue = _seed;

        while (true)
        {
            currX += direction.Dx;
            currY += direction.Dy;

            if (currX < 0 || currX >= rows)
            {
                break;
            }

            if (currY < 0 || currY >= columns)
            {
                break;
            }

            baseValue = _aggregation(actualValue, matrix[currX][currY], baseValue);
                
            if (matrix[currX][currY] >= actualValue)
            {
                return baseValue;
            }
        }
            
        return baseValue;
    }
}
