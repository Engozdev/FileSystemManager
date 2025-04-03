using FluentChaining;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.FileLinks;

public class RenameLink : ILink<Arguments, ICommand?>
{
    public ICommand? Process(
        Arguments request,
        SynchronousContext context,
        LinkDelegate<Arguments, SynchronousContext, ICommand?> next)
    {
        if (request.Positional is not ["rename", _, _])
            return next(request, context);

        return new RenameCommand(request.Positional[1], request.Positional[2]);
    }
}