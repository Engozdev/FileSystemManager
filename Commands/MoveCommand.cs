using Itmo.ObjectOrientedProgramming.Lab4.Contexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class MoveCommand : ICommand
{
    private readonly string _from;
    private readonly string _to;

    public MoveCommand(string from, string to)
    {
        _from = from;
        _to = to;
    }

    public void Execute(IContext context)
    {
        string from = context.GetFullPath(_from);
        context.FileSystem?.MoveFile(from, _to);
    }
}