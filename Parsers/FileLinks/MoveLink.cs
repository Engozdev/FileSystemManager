using FluentChaining;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.FileLinks;

public class MoveLink : ILink<Arguments, ICommand?>
{
    public ICommand? Process(
        Arguments request,
        SynchronousContext context,
        LinkDelegate<Arguments, SynchronousContext, ICommand?> next)
    {
        if (request.Positional is not ["move", _, _])
            return next(request, context);

        return new MoveCommand(request.Positional[1], request.Positional[2]);
    }
}