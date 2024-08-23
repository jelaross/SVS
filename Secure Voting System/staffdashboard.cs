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
        public staffdashboard()
        {
            InitializeComponent();
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            addvoters obj = new addvoters();
            obj.Show();
        }

        private void toolStripLabel5_Click(object sender, EventArgs e)
        {
            viewvoter obj = new viewvoter();
            obj.Show();
        }
    }
}
