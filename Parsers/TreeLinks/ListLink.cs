using FluentChaining;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using System.Globalization;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.TreeLinks;

public class ListLink : ILink<Arguments, ICommand?>
{
    public ICommand? Process(
        Arguments request,
        SynchronousContext context,
        LinkDelegate<Arguments, SynchronousContext, ICommand?> next)
    {
        if (request.Positional is not ["list"])
            return next(request, context);

        int depth = 1;
        string? depthString = request.TryGetFlag("-d");
        if (depthString is not null)
            depth = int.Parse(depthString, CultureInfo.InvariantCulture);

        return new TreeListCommand(depth);
    }
}