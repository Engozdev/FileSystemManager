using Itmo.ObjectOrientedProgramming.Lab4.Components;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Printers;
using Itmo.ObjectOrientedProgramming.Lab4.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeListCommand : ICommand
{
    private readonly IVisitor _visitor;

    public TreeListCommand(int depth = 1)
    {
        _visitor = new Visitor(new ConsolePrinter(), depth);
    }

    public void Execute(IContext context)
    {
        var node = new DirectoryNode(context.CurrentPath);
        node.Accept(_visitor);
    }
}