using System;
using System.Collections.Generic;
using System.IO;

namespace FileScannerApp
{
    public static class Organizer
    {
        public static string OrganizeFiles(
            string sourceFolder,
            string destinationFolder,
            List<string> fileTypes,
            string operation,
            bool createSubfolders,
            bool overwriteExisting,
            bool addNumericSuffix)
        {
            if (!Directory.Exists(sourceFolder))
                throw new DirectoryNotFoundException("Folder źródłowy nie istnieje.");

            if (!Directory.Exists(destinationFolder))
                Directory.CreateDirectory(destinationFolder);

            var files = Directory.GetFiles(sourceFolder, "*.*", SearchOption.TopDirectoryOnly);

            foreach (var file in files)
            {
                string ext = Path.GetExtension(file).ToLower();

                if (!fileTypes.Contains(ext))
                    continue;

                string targetFolder = destinationFolder;

                if (createSubfolders)
                {
                    string typeFolder = GetTypeFolder(ext);
                    targetFolder = Path.Combine(destinationFolder, typeFolder);

                    if (!Directory.Exists(targetFolder))
                        Directory.CreateDirectory(targetFolder);
                }

                string fileName = Path.GetFileName(file);
                string targetPath = Path.Combine(targetFolder, fileName);

                if (File.Exists(targetPath))
                {
                    if (overwriteExisting)
                    {
                        if (operation == "move") File.Delete(targetPath);
                    }
                    else if (addNumericSuffix)
                    {
                        int counter = 1;
                        string nameWithoutExt = Path.GetFileNameWithoutExtension(file);
                        string extension = Path.GetExtension(file);

                        do
                        {
                            targetPath = Path.Combine(targetFolder, $"{nameWithoutExt}({counter}){extension}");
                            counter++;
                        } while (File.Exists(targetPath));
                    }
                    else
                    {
                        continue;
                    }
                }

                if (operation == "move")
                    File.Move(file, targetPath);
                else
                    File.Copy(file, targetPath);
            }

            return destinationFolder;
        }

        private static string GetTypeFolder(string ext)
        {
            switch (ext)
            {
                case ".exe":
                case ".msi":
                case ".bat":
                    return "Executables";
                case ".pdf":
                case ".docx":
                case ".txt":
                    return "Documents";
                case ".jpg":
                case ".png":
                case ".bmp":
                case ".gif":
                    return "Images";
                case ".mp4":
                case ".avi":
                case ".mkv":
                    return "Videos";
                default:
                    return "Others";
            }
        }
    }
}