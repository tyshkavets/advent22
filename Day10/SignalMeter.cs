namespace Day10;

public class SignalMeter : IClockDrivenDevice
{
    public int Accumulator { get; private set; }

    public void Pulse(int currentCycle, int currentX)
    {
        if ((currentCycle - 20) % 40 == 0)
        {
            Accumulator += currentCycle * currentX;
        }
    }

    public void PostPulse(int currentCycle, int currentX)
    {
    }
}