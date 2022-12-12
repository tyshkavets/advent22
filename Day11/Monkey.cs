namespace Day11;

public class Monkey
{
    private readonly Queue<long> _queue = new();

    public int DivisibleCheck { get; private init; }

    private OperationType Operation { get; set; }

    private int Argument { get; set; }    

    private int TruthyMonkeyIndex { get; init; }

    private int FalseyMonkeyIndex { get; init; }
    
    public int Counter { get; private set; }

    public static Monkey ParseMonkey(string monkeySpec)
    {
        var lines = monkeySpec.Split(Environment.NewLine);

        var monkey = new Monkey
        {
            DivisibleCheck = int.Parse(lines[3][21..]),
            TruthyMonkeyIndex = int.Parse(lines[4][29..]),
            FalseyMonkeyIndex = int.Parse(lines[5][30..]),
        };

        ParseMonkeyItems(lines, monkey);
        ParseMonkeyOperation(lines, monkey);

        return monkey;

        void ParseMonkeyItems(IReadOnlyList<string> monkeyDescription, Monkey monkeyToBuild)
        {
            var items = monkeyDescription[1][18..].Split(',').Select(n => n.Trim()).Select(long.Parse);
            foreach (var item in items)
            {
                monkeyToBuild._queue.Enqueue(item);
            }
        }

        void ParseMonkeyOperation(IReadOnlyList<string> monkeyDescription, Monkey monkeyToBuild)
        {
            var operationContent = monkeyDescription[2][23..];

            if (operationContent == "* old")
            {
                monkeyToBuild.Operation = OperationType.Square;
            }
            else if (operationContent[0] == '*')
            {
                monkeyToBuild.Operation = OperationType.Multiply;
                monkeyToBuild.Argument = int.Parse(operationContent[2..]);
            }
            else
            {
                monkeyToBuild.Operation = OperationType.Add;
                monkeyToBuild.Argument = int.Parse(operationContent[2..]);
            }
        }
    }

    public bool HasGotItemsToPlayWith()
    {
        return _queue.Count > 0;
    }

    public void CatchItem(long worry)
    {
        _queue.Enqueue(worry);
    }

    public (long WorryLevel, int TargetMonkey) Play(long commonModulo, bool calm = true)
    {
        Counter++;
        var item = _queue.Dequeue();

        switch (Operation)
        {
            case OperationType.Add:
                item += Argument;
                break;
            case OperationType.Multiply:
                item *= Argument;
                break;
            case OperationType.Square:
                item *= item;
                break;
        }

        if (calm)
        {
            item /= 3;
        }

        if (commonModulo > 0)
        {
            item %= commonModulo;
        }

        return item % DivisibleCheck == 0 ? (item, TruthyMonkeyIndex) : (item, FalseyMonkeyIndex);
    }
}