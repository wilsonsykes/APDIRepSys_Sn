// File: ImageResizer.cs
using System;
using System.Drawing;
using System.IO;

namespace MyRep.Utilities
{
    public static class ImageResizer
    {
        public static string ResizeToBox(string originalPath, int maxWidth, int maxHeight)
        {
            if (!File.Exists(originalPath)) return null;

            try
            {
                using (Image originalImage = Image.FromFile(originalPath))
                {
                    float ratioX = (float)maxWidth / originalImage.Width;
                    float ratioY = (float)maxHeight / originalImage.Height;
                    float ratio = Math.Min(ratioX, ratioY);

                    int newWidth = (int)(originalImage.Width * ratio);
                    int newHeight = (int)(originalImage.Height * ratio);

                    Bitmap resizedImage = new Bitmap(newWidth, newHeight);
                    using (Graphics g = Graphics.FromImage(resizedImage))
                    {
                        g.Clear(Color.White); // Optional
                        g.DrawImage(originalImage, 0, 0, newWidth, newHeight);

                    }

                    string tempDir = Path.Combine(Path.GetTempPath(), "APDIImages");
                    Directory.CreateDirectory(tempDir);

                    string newPath = Path.Combine(tempDir, Path.GetFileName(originalPath));
                    resizedImage.Save(newPath, System.Drawing.Imaging.ImageFormat.Png);

                    return newPath;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
