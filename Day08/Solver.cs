namespace Day08;

public class Solver<T>
{
    private readonly List<(int Dx, int Dy)> _visibilityVectors = new()
    {
        (1, 0),
        (0, 1),
        (-1, 0),
        (0, -1)
    };

    private readonly T _accumulatorSeed;
    private readonly Func<T, T, T> _accumulator;
    private readonly Func<IEnumerable<T>, int> _resultAgg;
    private readonly T _singleItemSeed;
    private readonly Func<byte, byte, T, T> _singleItemAggregation;

    public Solver(
        T accumulatorSeed,
        Func<T, T, T> accumulator,
        Func<IEnumerable<T>, int> resultAgg,
        T singleItemSeed,
        Func<byte, byte, T, T> singleItemAggregation)
    {
        _accumulatorSeed = accumulatorSeed;
        _accumulator = accumulator;
        _resultAgg = resultAgg;
        _singleItemSeed = singleItemSeed;
        _singleItemAggregation = singleItemAggregation;
    }


    public int Solve(byte[][] matrix)
    {
        var rows = matrix.Length;
        var columns = matrix[0].Length;
        var resultMatrix = new T[rows][];

        for (var i = 0; i < rows; i++)
        {
            resultMatrix[i] = new T[columns];
        }

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                resultMatrix[i][j] = _visibilityVectors
                    .Select(v => GetSingleItemScore(matrix, i, j, v))
                    .Aggregate(_accumulatorSeed, _accumulator);
            }
        }

        return _resultAgg(resultMatrix.SelectMany(r => r));
    }

    private T GetSingleItemScore(byte[][] matrix, int currX, int currY, (int Dx, int Dy) direction)
    {
        var scorer = new SingleItemCalculator<T>(_singleItemSeed, _singleItemAggregation);

        return scorer.Solve(matrix, currX, currY, direction);
    }
}
