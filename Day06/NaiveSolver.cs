namespace Day06;

public class NaiveSolver
{
    public static int Solve(string input, int length)
    {
        for (var i = length - 1; i < input.Length; i++)
        {
            var testMarker = input.Substring(i - length + 1, length);

            if (testMarker.Distinct().Count() == length)
            {
                return i + 1;
            }
        }

        throw new Exception();
    }
}