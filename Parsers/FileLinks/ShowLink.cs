using FluentChaining;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Printers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.FileLinks;

public class ShowLink : ILink<Arguments, ICommand?>
{
    public ICommand? Process(
        Arguments request,
        SynchronousContext context,
        LinkDelegate<Arguments, SynchronousContext, ICommand?> next)
    {
        if (request.Positional is not ["show", _])
            return next(request, context);

        IPrinter printer = new ConsolePrinter();
        string? mode = request.TryGetFlag("-m");
        if (mode is not null)
        {
            printer = mode switch
            {
                "console" => new ConsolePrinter(),
                _ => throw new ArgumentException("Invalid argument" + nameof(mode)),
            };
        }

        return new FilePrintCommand(request.Positional[1], printer);
    }
}