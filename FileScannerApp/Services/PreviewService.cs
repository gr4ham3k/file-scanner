using DocumentFormat.OpenXml.Packaging;
using Microsoft.Web.WebView2.WinForms;
using OpenXmlPowerTools;
using PdfiumViewer;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

public static class PreviewService
{
    public static void Show(string filePath, Panel previewPanel)
    {
        previewPanel.Controls.Clear();

        string ext = Path.GetExtension(filePath).ToLower();

        if (new[] { ".jpg", ".png", ".bmp", ".gif" }.Contains(ext))
        {
            PictureBox pb = new PictureBox();
            pb.Dock = DockStyle.Fill;
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.Image = Image.FromFile(filePath);
            previewPanel.Controls.Add(pb);
        }
        else if (ext == ".txt")
        {
            RichTextBox rtb = new RichTextBox();
            rtb.Dock = DockStyle.Fill;
            rtb.ReadOnly = true;
            rtb.Text = File.ReadAllText(filePath);
            previewPanel.Controls.Add(rtb);
        }
        else if (new[] { ".mp3", ".wav", ".mp4" }.Contains(ext))
        {
            var player = new AxWMPLib.AxWindowsMediaPlayer();
            previewPanel.Controls.Add(player);
            player.Dock = DockStyle.Fill;
            player.CreateControl();
            player.BeginInit();
            player.URL = filePath;
            player.EndInit();
        }
        else if (ext == ".pdf")
        {
            var pdfViewer = new PdfViewer();
            pdfViewer.Dock = DockStyle.Fill;
            pdfViewer.Document = PdfDocument.Load(filePath);
            previewPanel.Controls.Add(pdfViewer);
        }
        else
        {
            Label lbl = new Label();
            lbl.Dock = DockStyle.Fill;
            lbl.Text = "Podgląd tego typu pliku nie jest obsługiwany.";
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            previewPanel.Controls.Add(lbl);
        }
    }

}