namespace Day05;

public class InputParser
{
    public (GameState GameState, IEnumerable<Move> Moves) Parse(string input)
    {
        var splitInput = input.Split(Environment.NewLine + Environment.NewLine);

        var initialState = splitInput[0].Split(Environment.NewLine);
        var indexRow = initialState.Last().Split("   ");
        var result = new GameState();
        var countOfPillars = indexRow.Length;
        result.AllPillars = new List<Pillar>(indexRow.Length);

        for (int i = 0; i < countOfPillars; i++)
        {
            result.AllPillars.Add(new Pillar());
        }

        foreach (var currentRow in initialState.SkipLast(1))
        {
            PopulateRow(countOfPillars, currentRow, result);
        }

        return (result, ParseMoves(splitInput[1]));
    }

    private static void PopulateRow(int countOfPillars, string currentRow, GameState gameState)
    {
        for (var i = 0; i < countOfPillars; i++)
        {
            var currentCharIndex = i * 4 + 1;
            if (currentRow.Length <= currentCharIndex || currentRow[currentCharIndex] == ' ')
            {
                continue;
            }

            gameState.AllPillars[i].Prepend(currentRow[currentCharIndex]);
        }
    }

    private static IEnumerable<Move> ParseMoves(string moves)
    {
        var movesList = moves.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        return movesList.Select(moveString => moveString.Split(' ')).Select(words =>
            new Move(int.Parse(words[3]) - 1, int.Parse(words[5]) - 1, int.Parse(words[1]))).ToList();
    }
}
