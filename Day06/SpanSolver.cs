namespace Day06;

public class SpanSolver
{
    public static int Solve(string input, int length)
    {
        var span = input.AsSpan();
        
        for (var i = length - 1; i < input.Length; i++)
        {
            var testMarker = span.Slice(i - length + 1, length);

            if (!ManualCheck(testMarker))
            {
                return i + 1;
            }
        }

        throw new Exception();
    }

    private static bool ManualCheck(ReadOnlySpan<char> t)
    {
        for (var i = 0; i < t.Length - 1; i++)
        {
            for (var j = i+1; j < t.Length; j++)
            {
                if (t[i] == t[j])
                {
                    return true;
                }
            }
        }

        return false;
    }
}