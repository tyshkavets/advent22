namespace Day09;

/// <summary>
/// A wonderful example of caching that takes more
/// </summary>
public class CachingStepper : IStepper
{
    private readonly IStepper _stepper = new Stepper();

    private readonly Dictionary<(int, int, int, int, bool), (int, int, int, int)> _cache = new();

    public (CellPosition NewHead, CellPosition NewTail) GetStep(CellPosition head, CellPosition tail, int moveDeltaX,
        int moveDeltaY, bool applyMoveToHead = true)
    {
        var startDiffX = head.X - tail.X;
        var startDiffY = head.Y - tail.Y;

        if (_cache.ContainsKey((startDiffX, startDiffY, moveDeltaX, moveDeltaY, applyMoveToHead)))
        {
            var (headDeltaX, headDeltaY, tailDeltaX, tailDeltaY) =
                _cache[(startDiffX, startDiffY, moveDeltaX, moveDeltaY, applyMoveToHead)];

            var newHead = new CellPosition(head.X + headDeltaX, head.Y + headDeltaY);
            var newTail = new CellPosition(tail.X + tailDeltaX, tail.Y + tailDeltaY);

            return (newHead, newTail);
        }

        var result = _stepper.GetStep(head, tail, moveDeltaX, moveDeltaY, applyMoveToHead);

        _cache[(startDiffX, startDiffY, moveDeltaX, moveDeltaY, applyMoveToHead)] =
            (result.NewHead.X - head.X, result.NewHead.Y - head.Y, result.NewTail.X - tail.X,
                result.NewTail.Y - tail.Y);

        return result;
    }
}