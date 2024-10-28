using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FixImages
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string[] files;
            string saveFolder;
            string str;
            MemoryStream ms = new MemoryStream();
            Bitmap bmp;
            FolderBrowserDialog dialog = new FolderBrowserDialog
            {
                ShowNewFolderButton = false,
                Description = Application.ProductName + " v" + Application.ProductVersion
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                files = Directory.GetFiles(dialog.SelectedPath);
                saveFolder = Path.Combine(dialog.SelectedPath, "OutputPNGImages-" + DateTime.Now.Ticks.ToString());
                Directory.CreateDirectory(saveFolder);
                for (int i = 0; i < files.Length; i++)
                {
                    if (string.Equals(Path.GetExtension(files[i]), ".png", StringComparison.OrdinalIgnoreCase))
                    {
                        bmp = new Bitmap(files[i]);
                        str = Path.Combine(saveFolder, Path.GetFileName(files[i]));
                        bmp.Save(str, System.Drawing.Imaging.ImageFormat.Png);
                    }
                }
            }
        }
    }
}
