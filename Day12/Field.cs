namespace Day12;

public class Field
{
    private readonly string[] _map;

    private readonly int _height;
    private readonly int _width;
    
    public Field(string[] map)
    {
        _map = map;
        _height = map.Length;
        _width = map[0].Length;
    }

    public int FindPath()
    {
        var start = GetStartingPosition();
        var finish = GetFinishingPosition();

        var toLook = new Queue<(int X, int Y)>();
        var memory = new int[_height][];
        for (var i = 0; i < _height; i++)
        {
            memory[i] = new int[_width];
        }
        toLook.Enqueue(start);
        memory[start.X][start.Y] = 1;

        while (toLook.TryDequeue(out var curr))
        {
            EnqueueInDirection(curr, 1, 0, memory, toLook);
            EnqueueInDirection(curr, -1, 0, memory, toLook);
            EnqueueInDirection(curr, 0, 1, memory, toLook);
            EnqueueInDirection(curr, 0, -1, memory, toLook);

            if (memory[finish.X][finish.Y] > 0)
            {
                break;
            }
        }

        return memory[finish.X][finish.Y] - 1;
    }

    public int FindScenicRoute()
    {
        var finish = GetFinishingPosition();
        
        var toLook = new Queue<(int X, int Y)>();
        var memory = new int[_height][];
        for (var i = 0; i < _height; i++)
        {
            memory[i] = new int[_width];
        }
        toLook.Enqueue(finish);
        memory[finish.X][finish.Y] = 1;
        
        while (toLook.TryDequeue(out var curr))
        {
            EnqueueInDirection(curr, 1, 0, memory, toLook, true);
            EnqueueInDirection(curr, -1, 0, memory, toLook, true);
            EnqueueInDirection(curr, 0, 1, memory, toLook, true);
            EnqueueInDirection(curr, 0, -1, memory, toLook, true);

            if (GetElevation(_map[curr.X][curr.Y]) == 0)
            {
                return memory[curr.X][curr.Y] - 1;
            }
        }

        throw new InvalidOperationException();
    }

    private void EnqueueInDirection((int X, int Y) position, int deltaX, int deltaY, int[][]? memory,
        Queue<(int X, int Y)>? toLook, bool reverseDirection = false)
    {
        var toX = position.X + deltaX;
        var toY = position.Y + deltaY;

        switch (reverseDirection)
        {
            case false when !CanGo(position.X, position.Y, toX, toY):
            case true when !CanGo(toX, toY, position.X, position.Y):
                return;
        }

        if (memory[toX][toY] != 0)
        {
            return;
        }

        toLook.Enqueue((toX, toY));
        memory[toX][toY] = memory[position.X][position.Y] + 1;
    }

    private (int X, int Y) GetStartingPosition() => GetPosition('S');
    private (int X, int Y) GetFinishingPosition() => GetPosition('E');

    private (int X, int Y) GetPosition(char symbol)
    {
        for (var i = 0; i < _height; i++)
        {
            var here = _map[i].IndexOf(symbol);

            if (here >= 0)
            {
                return (i, here);
            }
        }

        throw new InvalidOperationException();
    }

    private bool CanGo(int fromX, int fromY, int toX, int toY)
    {
        if (toX < 0 || toY < 0  || fromX < 0 || fromY < 0)
        {
            return false;
        }

        if (toX >= _height || fromX >= _height)
        {
            return false;
        }

        if (toY >= _width || fromY >= _width)
        {
            return false;
        }

        if (GetElevation(_map[toX][toY]) - GetElevation(_map[fromX][fromY]) <= 1)
        {
            return true;
        }

        return false;
    }

    private static int GetElevation(char coord)
    {
        if (char.IsLower(coord))
        {
            return coord - 'a';
        }

        return coord switch
        {
            'S' => 0,
            'E' => 25,
            _ => throw new InvalidOperationException()
        };
    }
}