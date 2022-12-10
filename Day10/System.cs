namespace Day10;

public class System
{
    private readonly Clock _clock;

    private Cpu Cpu { get; }

    public Screen Screen { get; }

    public SignalMeter SignalMeter { get; }

    private readonly IEnumerable<IClockDrivenDevice> _devicesToTick;

    public System(string[] input)
    {
        _clock = new Clock(this);
        Cpu = new Cpu(input, this);
        Screen = new Screen();
        SignalMeter = new SignalMeter();

        _devicesToTick = new IClockDrivenDevice[] { Cpu, Screen, SignalMeter };
    }

    public void RaiseTick(int currentCycle)
    {
        foreach (var clockDrivenDevice in _devicesToTick)
        {
            clockDrivenDevice.Pulse(currentCycle, Cpu.X);
        }

        foreach (var clockDrivenDevice in _devicesToTick)
        {
            clockDrivenDevice.PostPulse(currentCycle, Cpu.X);
        }
    }

    public void RaiseHalt()
    {
        _clock.InvokeHaltInterrupt();
    }

    public void Process()
    {
        _clock.Run();
    }
}