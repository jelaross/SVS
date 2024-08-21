using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Secure_Voting_System
{
    public partial class viewelection : Form
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-HVOUKVA; database=voting_system; Integrated Security=true");
        public viewelection()
        {
            InitializeComponent();
            fillgrid(dataGridView1);
        }
        public void fillgrid(DataGridView js)
        {

            con.Open();
            string str = "select * from election";
            DataSet ds = new DataSet();
            SqlDataAdapter sqlda = new SqlDataAdapter(str, con);
            sqlda.Fill(ds);
            js.DataSource = ds.Tables[0].DefaultView;
            con.Close();
        }
    }
}
