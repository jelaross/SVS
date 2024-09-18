using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using Secure_Voting_System.Properties;

public class FloatingNotification
{
    private Label _label;
    private Timer _timer;

    public FloatingNotification(Control parent, string message, string color = "blue", int timeout = 2000, int x = 10, int y = 10)
    {
        _label = new Label
        {
            AutoSize = true,
            Text = message,
            Font = new Font("Segoe UI", 12),
            ForeColor = Color.White,
            BackColor = ColorTranslator.FromHtml(color),
            Padding = new Padding(10),
            BorderStyle = BorderStyle.FixedSingle
        };

        parent.Controls.Add(_label);

        _label.Location = new Point(x,y);

        _timer = new Timer { Interval = timeout };
        _timer.Tick += (sender, e) => _label.Dispose();
        _timer.Start();
    }
}


public class ImageResizer
{
    public static void ResizeImage(string inputPath, string outputPath, int width, int height)
    {
        // Load the original image
        using (Image originalImage = Image.FromFile(inputPath))
        {
            // Create a new bitmap with the desired size
            using (Bitmap resizedImage = new Bitmap(width, height))
            {
                // Create a Graphics object from the bitmap
                using (Graphics graphics = Graphics.FromImage(resizedImage))
                {
                    // Set the quality of the resizing
                    graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                    // Draw the original image onto the new bitmap with the new size
                    graphics.DrawImage(originalImage, 0, 0, width, height);
                }

                // Save the resized image to the specified path
                resizedImage.Save(outputPath);
            }
        }
    }
}
