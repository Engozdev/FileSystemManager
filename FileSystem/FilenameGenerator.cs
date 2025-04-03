namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public class FilenameGenerator
{
    public static string Generate(string fileName, string directory)
    {
        ArgumentNullException.ThrowIfNull(fileName, nameof(fileName));

        int counter = 0;
        string uniqueFileName = fileName[(fileName.LastIndexOf(Path.DirectorySeparatorChar) + 1)..];
        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
        string extension = Path.GetExtension(fileName);

        while (Path.Exists(Path.Combine(directory, uniqueFileName)))
        {
            uniqueFileName = $"{fileNameWithoutExtension}({counter}){extension}";
            counter++;
        }

        return uniqueFileName;
    }
}