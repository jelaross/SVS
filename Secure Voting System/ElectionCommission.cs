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
        public ElectionCommission()
        {
            InitializeComponent();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            staffadd obj = new staffadd();
            obj.Show();
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            viewstaff obj = new viewstaff();
            obj.Show();
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            addelection obj = new addelection();
            obj.Show();
        }

        private void toolStripLabel5_Click(object sender, EventArgs e)
        {
            viewelection obj = new viewelection();
            obj.Show();
        }

        private void toolStripLabel6_Click(object sender, EventArgs e)
        {
            Addcandidate obj = new Addcandidate();
            obj.Show();
        }

        private void toolStripLabel7_Click(object sender, EventArgs e)
        {
            viewresult obj = new viewresult();
            obj.Show();
        }
    }
}
