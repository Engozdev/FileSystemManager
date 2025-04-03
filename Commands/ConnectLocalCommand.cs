using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class ConnectLocalCommand : ICommand
{
    private readonly string _path;

    public ConnectLocalCommand(string path)
    {
        _path = path;
    }

    public void Execute(IContext context)
    {
        if (context.FileSystem is not null)
            throw new ArgumentException("Already connected", nameof(context));

        context.Connect(new LocalFileSystem());
        context.UpdateCurrentPath(_path);
    }
}