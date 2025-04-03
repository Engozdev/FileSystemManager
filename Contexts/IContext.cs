using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Contexts;

public interface IContext
{
    IFileSystem? FileSystem { get; }

    string CurrentPath { get; }

    void Connect(IFileSystem fileSystem);

    void Disconnect();

    string GetFullPath(string path);

    void UpdateCurrentPath(string path);
}