namespace Day01;

public static class TaskLogic
{
    public static int CalculateTopElves(string input, int numberOfElves)
    {
        return input
            .Split(Environment.NewLine + Environment.NewLine)
            .Select(oneElf =>
                oneElf
                    .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .Sum())
            .OrderByDescending(elf => elf)
            .Take(numberOfElves)
            .Sum();
    }
}
