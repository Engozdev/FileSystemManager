using Itmo.ObjectOrientedProgramming.Lab4.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Components;

public interface INode
{
    public string Name { get; }

    public string FullPath { get; }

    public void Accept(IVisitor visitor);
}