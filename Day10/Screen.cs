namespace Day10;

public class Screen : IClockDrivenDevice
{
    public bool[] screen = new bool[240];

    public void Pulse(int currentCycle, int currentX)
    {
        var adjustedCycle = currentCycle % 240;
        var drawingPosition = adjustedCycle - 1;
        if (drawingPosition < 0)
        {
            drawingPosition = 239;
        }

        if (Math.Abs((drawingPosition % 40) - currentX) <= 1)
        {
            screen[drawingPosition] = true;
        }
        else
        {
            screen[drawingPosition] = false;
        }
    }

    public void PostPulse(int currentCycle, int currentX)
    {
    }
}