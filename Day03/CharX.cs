namespace Day03;

public static class CharX
{
    public static int GetPriority(this char itemType)
    {
        if (itemType is >= 'a' and <= 'z')
        {
            return (byte)itemType - 96;
        }

        return (byte)itemType - 38;
    }
}
