using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Secure_Voting_System
{
    public partial class staffdashboard : Form
    {
        public staffdashboard(String username_from_login)
        {
            InitializeComponent();
            lable_username.Text = username_from_login;
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            addvoters obj = new addvoters();
            obj.TopLevel = false;
            obj.Dock = DockStyle.Fill;
            panel2.Controls.Add(obj);
            obj.Show();
        }

        private void toolStripLabel5_Click(object sender, EventArgs e)
        {
            viewvoter obj = new viewvoter();
            panel2.Controls.Clear();
            obj.TopLevel = false;
            obj.Dock = DockStyle.Fill;
            panel2.Controls.Add(obj);
            obj.Show();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
