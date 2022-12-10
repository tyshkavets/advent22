namespace Day10;

public interface IClockDrivenDevice
{
    public void Pulse(int currentCycle, int currentX);
    public void PostPulse(int currentCycle, int currentX);
}