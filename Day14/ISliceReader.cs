namespace Day14;

public interface ISliceReader
{
    VerticalSlice GetSlice(IReadOnlyList<Chain> chains);
}