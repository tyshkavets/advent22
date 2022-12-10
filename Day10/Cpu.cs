namespace Day10;

public class Cpu : IClockDrivenDevice
{
    private readonly System _system;
    private const string NoOpOpcode = "noop";
    private const string AddOpcode = "addx";

    private readonly Queue<string> _instructions;
    private readonly Dictionary<int, int> _queuedAdditions = new();
    
    private int _haltTill = 1;

    public int X { get; private set; } = 1;
    
    public Cpu(IEnumerable<string> lines, System system)
    {
        _system = system;
        _instructions = new Queue<string>();
        
        foreach (var line in lines)
        {
            _instructions.Enqueue(line);
        }
    }

    public void Pulse(int currentCycle, int currentX)
    {
        if (currentCycle < _haltTill)
        {
            return;
        }

        if (_instructions.Count == 0)
        {
            _system.RaiseHalt();
            return;
        }

        var nextInstruction = ParseInstruction(_instructions.Dequeue());
        var length = GetInstructionLength(nextInstruction.Opcode);
        
        if (nextInstruction.Opcode == AddOpcode)
        {
            _queuedAdditions.Add(currentCycle + 1, nextInstruction.Value!.Value);
        }

        _haltTill = currentCycle + length;
    }
    
    private static (string Opcode, int? Value) ParseInstruction(string line)
    {
        return (line[..4], line.Length > 5 ? int.Parse(line[5..]) : default(int?));
    }
    
    private static int GetInstructionLength(string opcode) =>
        opcode switch
        {
            NoOpOpcode => 1,
            AddOpcode => 2,
            _ => throw new ArgumentOutOfRangeException(nameof(opcode), opcode),
        };

    public void PostPulse(int currentCycle, int currentX)
    {
        if (_queuedAdditions.ContainsKey(currentCycle))
        {
            X += _queuedAdditions[currentCycle];
        }
    }
}