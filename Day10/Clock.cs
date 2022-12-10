namespace Day10;

public class Clock
{
    private readonly System _system;
    private int _currentCycle;
    private bool _haltReceived;

    public Clock(System system)
    {
        _system = system;
    }
    
    public void Run()
    {
        while (!_haltReceived)
        {
            _currentCycle++;
            _system.RaiseTick(_currentCycle);
        }
    }

    public void InvokeHaltInterrupt()
    {
        _haltReceived = true;
    }
}