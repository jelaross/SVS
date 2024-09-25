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
    public partial class addvoters : Form
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-HVOUKVA; database=voting_system; Integrated Security=true");
        public addvoters()
        {
            InitializeComponent();
            fillcombo();
        }

        public void fillcombo()
        {
            string query = "select area from constituency";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr[0].ToString());

            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String usr, pass, name, dob, gender, address, constituency;
            usr = textBox1.Text;
            pass = textBox2.Text;
            name = textBox3.Text;
            dob = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            gender = comboBox1.Text;
            address = textBox4.Text;
            constituency= comboBox2.Text;

            if (usr== "")
            {
                MessageBox.Show("username is mandatory");
                return;
            }
            if (pass == "")
            {
                MessageBox.Show("password is mandatory");
                return;
            }
            if (name == "")
            {
                MessageBox.Show("name is mandatory");
                return;
            }
            if (address== "")
            {
                MessageBox.Show("address is mandatory");
                return;
            }
            if (dob == "")
            {
                MessageBox.Show("dob is mandatory");
                return;
            }
            
           
            
            if (constituency == "")
            {
                MessageBox.Show("constituency is mandatory");
                
                return;
            }

            con.Open();
            String query1 = "SELECT * FROM login_details WHERE username=@username";
            SqlCommand cmd = new SqlCommand(query1, con);
            cmd.Parameters.AddWithValue("@username", usr);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Username already taken");
                con.Close();
                return;
            }
            con.Close();
            String query2 = "INSERT INTO login_details VALUES(COALESCE((SELECT MAX(lid)+1 FROM login_details), 1), @username, @password, 'voter')";
            con.Open();
            SqlCommand cmd2 = new SqlCommand(query2, con);
            cmd2.Parameters.AddWithValue("@username", usr);
            cmd2.Parameters.AddWithValue("@password", pass);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            con.Close();
            String query3 = "INSERT INTO voter (vid,username,password,name,dob,gender,constituency,lid,address) VALUES(COALESCE((SELECT MAX(vid)+1 FROM voter), 1), @username, @password, @name, @dob, @gender, @constituency, (SELECT lid FROM login_details where username=@username), @address)";

            con.Open();
            SqlCommand cmd3 = new SqlCommand(query3, con);
            cmd3.Parameters.AddWithValue("@username", usr);
            cmd3.Parameters.AddWithValue("@password", pass);
            cmd3.Parameters.AddWithValue("@name", name);
            cmd3.Parameters.AddWithValue("@dob", dob);
            cmd3.Parameters.AddWithValue("gender", gender);
            cmd3.Parameters.AddWithValue("@address", address);
            cmd3.Parameters.AddWithValue("@constituency", constituency);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            MessageBox.Show("voter added successfully");
            con.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
