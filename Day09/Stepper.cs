namespace Day09;

public class Stepper : IStepper
{
    public (CellPosition NewHead, CellPosition NewTail) GetStep(
        CellPosition head,
        CellPosition tail,
        int moveDeltaX,
        int moveDeltaY,
        bool applyMoveToHead = true)
    {
        var newHead = applyMoveToHead ? new CellPosition(head.X + moveDeltaX, head.Y + moveDeltaY) : head;

        // No movement required if head and tail remain adjacent after the head is moved.
        if (AreAdjacent(newHead, tail))
        {
            return (newHead, tail);
        }

        var deltaXSign = Math.Sign(newHead.X - tail.X);
        var deltaYSign = Math.Sign(newHead.Y - tail.Y);

        var newTail = new CellPosition(X: tail.X + deltaXSign, Y: tail.Y + deltaYSign);

        return (newHead, newTail);
    }

    private static bool AreAdjacent(CellPosition head, CellPosition tail)
    {
        // If X or Y coordinates differ by more than one, cells are no longer adjacent.
        // There's probably an arithmetic way to do it with just one comparison instead of two, but I can't find it.
        return Math.Max(Math.Abs(head.X - tail.X), Math.Abs(head.Y - tail.Y)) <= 1;
    }
}