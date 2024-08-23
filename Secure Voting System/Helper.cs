using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class FloatingNotification
{
    private Label _label;
    private Timer _timer;

    public FloatingNotification(Control parent, string message, int timeout = 2000, int x = 10, int y = 10)
    {
        _label = new Label
        {
            AutoSize = true,
            Text = message,
            Font = new Font("Segoe UI", 12),
            ForeColor = Color.White,
            BackColor = Color.OrangeRed,
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