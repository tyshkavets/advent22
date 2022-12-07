namespace Day06;

public class SpanSolverGen2
{
    public static int Solve(string input, int length)
    {
        var span = input.AsSpan();
        
        for (var i = length - 1; i < input.Length; i++)
        {
            var testMarker = span.Slice(i - length + 1, length);
            var checkResult = ManualCheck(testMarker);

            if (!checkResult.HasValue)
            {
                return i + 1;
            }

            i += checkResult.Value;
        }

        throw new Exception();
    }

    private static int? ManualCheck(ReadOnlySpan<char> t)
    {
        for (var i = 0; i < t.Length - 1; i++)
        {
            for (var j = i+1; j < t.Length; j++)
            {
                if (t[i] == t[j])
                {
                    return i;
                }
            }
        }

        return default;
    }
}