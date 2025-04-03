namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public class Arguments
{
    public IList<string> Positional { get; } = new List<string>();

    private const int MaxFlags = 2;

    private readonly IList<string> _flags = new List<string>(new string[MaxFlags]);

    public void Parse(string[] values)
    {
        ArgumentNullException.ThrowIfNull(values, nameof(values));

        int i = 0;
        while (i < values.Length)
        {
            if (values[i][0] == '-')
            {
                string flag = values[i];
                i++;
                _flags[GetFlagIndex(flag)] = values[i];
            }
            else
            {
                Positional.Add(values[i]);
            }

            i++;
        }
    }

    public string? TryGetFlag(string flag)
    {
        int flagIdx = GetFlagIndex(flag);
        if (flagIdx == -1) return null;
        return _flags[flagIdx];
    }

    private int GetFlagIndex(string flag)
    {
        if (flag == "-d") return 0;
        if (flag == "-m") return 1;
        return -1;
    }
}