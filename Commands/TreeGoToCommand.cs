using Itmo.ObjectOrientedProgramming.Lab4.Contexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeGoToCommand : ICommand
{
    private readonly string _path;

    public TreeGoToCommand(string path)
    {
        _path = path;
    }

    public void Execute(IContext context)
    {
        string path = context.GetFullPath(_path);
        context.UpdateCurrentPath(path);
    }
}