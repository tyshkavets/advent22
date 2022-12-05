namespace Day05;

public class GameState
{
    public IList<Pillar> AllPillars = new List<Pillar>();

    public void ApplyMove(Move move, bool keepOrder = false)
    {
        var tail = AllPillars[move.FromIndex].CutOff(move.Count, keepOrder);
        
        AllPillars[move.ToIndex].Append(tail);
    }

    public string ReturnTop() => AllPillars.Aggregate(string.Empty, (current, allPillar) => current + allPillar.Top());
}
