namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public interface IFileSystem
{
    void CopyFile(string pathFrom, string pathTo);

    void DeleteFile(string path);

    void MoveFile(string pathFrom, string pathTo);

    void RenameFile(string path, string newName);
}