using HelperLibrary.Models.v1;

namespace HelperLibrary.Helpers;

public class FilePaths
{
    private readonly static string _basePath = Directory.GetParent(AppContext.BaseDirectory)!.FullName;

    /// <summary>
    /// Returns the full path for a specified type of file path.
    /// </summary>
    /// <param name="type">The type of file path, defined by the FilePathType enum.</param>
    /// <returns>The full path as a string. Returns the base path for BaseDirectory. For TemporaryFiles and LogFiles, returns paths within the base path, creating the directories if they don't exist.</returns>
    /// <exception cref="NotImplementedException">Thrown if an unrecognized FilePathType is provided.</exception>
    public static string ReturnFullPath(FilePathType type)
    {
        string path;

        switch (type)
        {
            case FilePathType.BaseDirectory:
                return _basePath;
            case FilePathType.TemporaryFiles:
                path = Path.Combine(_basePath, "temp");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                return path;
            case FilePathType.LogFiles:
                path = Path.Combine(_basePath, "logs");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                return path;
            default:
                throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Constructs and returns the full file path for a given file name within a specified directory type.
    /// </summary>
    /// <param name="type">The type of directory to place the file, defined by the FilePathType enum.</param>
    /// <param name="fileName">The name of the file for which to generate the full path.</param>
    /// <returns>The full file path combining the directory path (based on the specified type) and the file name.</returns>
    public static string GetFilePath(FilePathType type, string fileName)
    {
        return Path.Combine(ReturnFullPath(type), fileName);
    }

}
