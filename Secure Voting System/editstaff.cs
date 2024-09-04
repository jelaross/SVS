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
    public partial class editstaff : Form
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-HVOUKVA; database=voting_system; Integrated Security=true");
        public editstaff()
        {
            InitializeComponent();
            fillgrid(dataGridView1);
            fillcombo();
        }

        public void fillgrid(DataGridView js)
        {

            con.Open();
            string str = "select * from staff";
            DataSet ds = new DataSet();
            SqlDataAdapter sqlda = new SqlDataAdapter(str, con);
            sqlda.Fill(ds);
            js.DataSource = ds.Tables[0].DefaultView;
            con.Close();
        }

        private void viewstaff_Load(object sender, EventArgs e)
        {

        }
        public void fillcombo()
        {
            string query = "select sid from staff";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());
                comboBox2.Items.Add(dr[0].ToString());
            }
            con.Close();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "select  * from staff where sid='" + comboBox1.Text + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr[1].ToString();
                textBox2.Text = dr[2].ToString();
                textBox3.Text = dr[3].ToString();
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string query = "delete from staff where sid='" + comboBox2.Text + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("staff details deleted");
            }

            con.Close();
            fillgrid(dataGridView2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "update staff set name='" + textBox1.Text + "', dob='" + textBox2.Text + "',gender='" + textBox3.Text + "' where sid='" + comboBox1.Text + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            if (cmd.ExecuteNonQuery() > 0)
            {

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                comboBox1.Text = "";
                MessageBox.Show("value updated");

            }
           
            con.Close();
            fillgrid(dataGridView3);
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string query = "select  * from staff where sid='" + comboBox1.Text + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr[1].ToString();
                textBox2.Text = dr[2].ToString();
                textBox3.Text = dr[3].ToString();
            }
            con.Close();
        }

        
    }
}
