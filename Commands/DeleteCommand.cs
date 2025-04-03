using Itmo.ObjectOrientedProgramming.Lab4.Contexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class DeleteCommand : ICommand
{
    private readonly string _path;

    public DeleteCommand(string path)
    {
        _path = path;
    }

    public void Execute(IContext context)
    {
        string path = context.GetFullPath(_path);
        context.FileSystem?.DeleteFile(path);
    }
}