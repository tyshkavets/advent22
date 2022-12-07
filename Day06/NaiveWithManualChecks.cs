namespace Day06;

public class NaiveWithManualChecks
{
    public static int Solve(string input, int length)
    {
        for (var i = length - 1; i < input.Length; i++)
        {
            var testMarker = input.Substring(i - length + 1, length);

            if (!ManualCheck(testMarker))
            {
                return i + 1;
            }
        }

        throw new Exception();
    }

    private static bool ManualCheck(string t)
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