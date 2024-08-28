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
    public partial class ElectionCommission : Form
    {
        public ElectionCommission(String username_from_login)
        {
            InitializeComponent();
            lable_username.Text = username_from_login;
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            staffadd obj = new staffadd();
            obj.TopLevel = false;
            obj.Dock = DockStyle.Fill;
            panel2.Controls.Add(obj);
           
            obj.Show();
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            viewstaff obj = new viewstaff();
            obj.TopLevel = false;
            obj.Dock = DockStyle.Fill;
            panel2.Controls.Add(obj);
            obj.Show();
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            addelection obj = new addelection();
            obj.TopLevel = false;
            obj.Dock = DockStyle.Fill;
            panel2.Controls.Add(obj);
            obj.Show();
        }

        private void toolStripLabel5_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            viewelection obj = new viewelection();
            obj.TopLevel = false;
            obj.Dock = DockStyle.Fill;
            panel2.Controls.Add(obj);
            obj.Show();
            
        }

        private void toolStripLabel6_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            Addcandidate obj = new Addcandidate();
            obj.TopLevel = false;
            obj.Dock = DockStyle.Fill;
            panel2.Controls.Add(obj);
            obj.Show();
        }

        private void toolStripLabel7_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            viewresult obj = new viewresult();
            obj.TopLevel = false;
            obj.Dock = DockStyle.Fill;
            panel2.Controls.Add(obj);
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
