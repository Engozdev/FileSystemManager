using Itmo.ObjectOrientedProgramming.Lab4.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Components;

public class DirectoryNode : INode
{
    public string Name { get; }

    public string FullPath { get; }

    public DirectoryNode(string path)
    {
        FullPath = path;
        Name = path[(path.LastIndexOf(Path.DirectorySeparatorChar) + 1)..];
    }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}