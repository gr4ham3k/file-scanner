using System.IO;

public class FileScanner
{
    public static FileInfo[] Scan(string path)
    {
        DirectoryInfo dir = new DirectoryInfo(path);
        return dir.GetFiles();
    }
}