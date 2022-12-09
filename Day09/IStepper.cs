namespace Day09;

/// <summary>
/// Interface to abstract an operation of moving one segment of a chain once.
/// </summary>
public interface IStepper
{
    /// <summary>
    /// Calculates new positions of head and tail after head moves by given deltas.
    /// </summary>
    /// <param name="head">Initial position of head.</param>
    /// <param name="tail">Initial position of tail.</param>
    /// <param name="moveDeltaX">Change in X position of head.</param>
    /// <param name="moveDeltaY">Change in Y position of head.</param>
    /// <param name="applyMoveToHead">
    /// Whether or not head needs to be moved by given delta, or was already moved by given deltas elsewhere
    /// and just needs to propagate changes to the tail.
    /// </param>
    /// <returns>New positions for head and tail.</returns>
    (CellPosition NewHead, CellPosition NewTail) GetStep(
        CellPosition head,
        CellPosition tail,
        int moveDeltaX,
        int moveDeltaY,
        bool applyMoveToHead = true);
}