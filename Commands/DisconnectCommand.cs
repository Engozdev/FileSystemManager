using Itmo.ObjectOrientedProgramming.Lab4.Contexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class DisconnectCommand : ICommand
{
    public void Execute(IContext context)
    {
        if (context.FileSystem is null)
            throw new ArgumentException("File system doesn't connected", nameof(context));

        context.Disconnect();
    }
}