using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Contexts;

public class Context : IContext
{
    public IFileSystem? FileSystem { get; private set; }

    public string CurrentPath { get; private set; }

    public Context(string currentPath)
    {
        CurrentPath = currentPath;
    }

    public void Connect(IFileSystem fileSystem)
    {
        FileSystem = fileSystem;
    }

    public void Disconnect()
    {
        CurrentPath = string.Empty;
        FileSystem = null;
    }

    public void UpdateCurrentPath(string path)
    {
        CurrentPath = path;
    }

    public string GetFullPath(string path)
    {
        if (string.IsNullOrEmpty(CurrentPath))
        {
            throw new ArgumentException("Current path is empty" + nameof(CurrentPath));
        }

        if (Path.IsPathRooted(path))
            return path;
        return Path.Combine(CurrentPath, path);
    }
}