using FileScannerApp.Models;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

public class FolderService
{
    public static void ShowFilesFromDb(ListView listView, List<FileData> files)
    {
        listView.Items.Clear();


        foreach (var file in files)
        {
            ListViewItem item = new ListViewItem(file.Name);

            item.Tag = file.Path;

            if (file.Size / 1024 < 1)
                item.SubItems.Add("<1 KB");
            else
                item.SubItems.Add((file.Size / 1024) + " KB");

            item.SubItems.Add(file.ModifiedDate);
            item.SubItems.Add(file.Path);

            listView.Items.Add(item);
        }
    }
}