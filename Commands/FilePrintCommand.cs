using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Printers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FilePrintCommand : ICommand
{
    private readonly string _path;
    private readonly IPrinter _printer;

    public FilePrintCommand(string path, IPrinter printer)
    {
        _path = path;
        _printer = printer;
    }

    public void Execute(IContext context)
    {
        string path = context.GetFullPath(_path);
        string content = File.ReadAllText(path);
        _printer.Print(content);
    }
}