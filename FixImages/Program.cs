using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
            FolderBrowserDialog dialog = new FolderBrowserDialog
            {
                ShowNewFolderButton = false,
                Description = Application.ProductName + " v" + Application.ProductVersion
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                files = Directory.GetFiles(dialog.SelectedPath);
                saveFolder = Path.Combine(dialog.SelectedPath, "OutputImages-" + DateTime.Now.Ticks.ToString());
                Directory.CreateDirectory(saveFolder);
                for (int i = 0; i < files.Length; i++)
                {
                    if (string.Equals(Path.GetExtension(files[i]), ".png", StringComparison.OrdinalIgnoreCase))
                    {
                        new Bitmap(files[i]).Save(Path.Combine(saveFolder, Path.GetFileName(files[i])), System.Drawing.Imaging.ImageFormat.Png);
                    }
                    else if (string.Equals(Path.GetExtension(files[i]), ".ico", StringComparison.OrdinalIgnoreCase))
                    {
                        new Bitmap(files[i]).Save(Path.Combine(saveFolder, Path.GetFileName(files[i])), System.Drawing.Imaging.ImageFormat.Icon);
                    }
                }
            }
        }
    }
}
