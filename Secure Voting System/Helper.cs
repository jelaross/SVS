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

public class ottuPetti
{
    public ottuPetti(TableLayoutPanel table, SqlDataReader data){

        table.Visible = false;
        table.Controls.Clear();
        table.ColumnCount = 5;
        //table.RowCount = 20;
        int i = 0;
        while (data.Read())
        {
            Label name = new Label{
                AutoSize = true,
                Text = data[0].ToString(),
                Font = new Font("Segoe UI", 12),
                ForeColor = Color.White,
                //BackColor = Color.OrangeRed,
                Padding = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle
            };

            Label party = new Label
            {
                AutoSize = true,
                Text = data[1].ToString(),
                Font = new Font("Segoe UI", 12),
                ForeColor = Color.White,
                //BackColor = Color.OrangeRed,
                Padding = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle
            };

            PictureBox symbol = new PictureBox
            {
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = Image.FromFile(data[2].ToString()),
            };

            PictureBox photo = new PictureBox
            {
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = Image.FromFile(data[3].ToString()),
            };

            Button btn = new Button { 
                Text = "VOTE",
                
            };
          

            table.Controls.Add(name, 0, i);
            table.Controls.Add(party, 1, i);
            table.Controls.Add(symbol, 2, i);
            table.Controls.Add(photo, 3, i);
            table.Controls.Add( btn,4, i);

            i++;

        }

        table.Visible = true;

    }
}