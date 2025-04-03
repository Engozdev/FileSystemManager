using Itmo.ObjectOrientedProgramming.Lab4.Components;

namespace Itmo.ObjectOrientedProgramming.Lab4.Visitors;

public interface IVisitor
{
    void SetDepth(int depth);

    void Visit(FileNode fileNode);

    void Visit(DirectoryNode directoryNode);
}