using System.IO;

public class FileScannerService
{
    public static FileInfo[] Scan(string path)
    {
        DirectoryInfo dir = new DirectoryInfo(path);
        return dir.GetFiles();
    }
}