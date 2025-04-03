namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public class LocalFileSystem : IFileSystem
{
    public void CopyFile(string pathFrom, string pathTo)
    {
        string newFileName = FilenameGenerator.Generate(pathFrom, pathTo);
        File.Copy(pathFrom, Path.Combine(pathTo, newFileName));
    }

    public void DeleteFile(string path)
    {
        File.Delete(path);
    }

    public void MoveFile(string pathFrom, string pathTo)
    {
        string newFileName = FilenameGenerator.Generate(pathFrom, pathTo);
        File.Move(pathFrom, Path.Combine(pathTo, newFileName));
    }

    public void RenameFile(string path, string newName)
    {
        ArgumentNullException.ThrowIfNull(path, nameof(path));

        string pathWithoutName = path[..path.LastIndexOf(Path.DirectorySeparatorChar)];
        File.Move(path, Path.Combine(pathWithoutName, newName));
    }
}