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
    public partial class editelection : Form
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-HVOUKVA; database=voting_system; Integrated Security=true");
        public editelection()
        {
            InitializeComponent();
            fillgrid(dataGridView1);
            fillgrid(dataGridView2);
            fillcombo();
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
        public void fillcombo()
        {
            string query = "select eid from election";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr[0].ToString());
            }
            con.Close();
        }

       
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "delete from election where eid='" + comboBox2.Text + "'";
            String query1 = "delete from candidate where eid='" + comboBox2.Text + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlCommand cmd1 = new SqlCommand(query1, con);
            if (cmd.ExecuteNonQuery() > 0 && cmd1.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("election details deleted");
            }
            con.Close();

            fillgrid(dataGridView1);
            fillgrid(dataGridView2);           
        }

        //private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}


        //private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}
    }
}
