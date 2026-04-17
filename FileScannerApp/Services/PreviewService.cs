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
            var pb = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            byte[] bytes = File.ReadAllBytes(filePath);
            var ms = new MemoryStream(bytes);

            pb.Image = Image.FromStream(ms);
            pb.Tag = ms;

            previewPanel.Controls.Add(pb);
        }
        else if (ext == ".txt")
        {
            var rtb = new RichTextBox
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                Text = File.ReadAllText(filePath)
            };

            previewPanel.Controls.Add(rtb);
        }
        else if (new[] { ".mp3", ".wav", ".mp4" }.Contains(ext))
        {
            var player = new AxWMPLib.AxWindowsMediaPlayer();
            player.Dock = DockStyle.Fill;
            player.CreateControl();
            player.URL = filePath;

            previewPanel.Controls.Add(player);
        }
        else if (ext == ".pdf")
        {
            var pdfViewer = new PdfViewer();
            pdfViewer.Dock = DockStyle.Fill;

            byte[] bytes = File.ReadAllBytes(filePath);
            var ms = new MemoryStream(bytes);

            pdfViewer.Document = PdfDocument.Load(ms);

            previewPanel.Controls.Add(pdfViewer);
        }
        else
        {
            var lbl = new Label
            {
                Dock = DockStyle.Fill,
                Text = "Preview not supported.",
                TextAlign = ContentAlignment.MiddleCenter
            };

            previewPanel.Controls.Add(lbl);
        }
    }
}