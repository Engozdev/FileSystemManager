using FluentChaining;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.ConnectLinks;

public class ConnectLink : ILink<Arguments, ICommand?>
{
    public ICommand? Process(
        Arguments request,
        SynchronousContext context,
        LinkDelegate<Arguments, SynchronousContext, ICommand?> next)
    {
        string? mode = request.TryGetFlag("-m");
        if (mode is not null and not "local")
            return next(request, context);
        if (request.Positional is not ["connect", _])
            return next(request, context);

        return new ConnectLocalCommand(request.Positional[1]);
    }
}