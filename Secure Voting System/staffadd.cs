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
    public partial class staffadd : Form
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-HVOUKVA; database=voting_system; Integrated Security=true");
        public staffadd()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            String usr = textBox1.Text;
            String pass = textBox2.Text;
            String name = textBox3.Text;
            String dob = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            String gender = comboBox1.Text;
            String address = textBox5.Text;

            if (usr == "") {
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
            if (dob == "")
            {
                MessageBox.Show("dob is mandatory");
                return;
            }
            if (gender == "")
            {
                MessageBox.Show("gender is mandatory");
                return;
            }
            if (address == "")
            {
                MessageBox.Show("address is mandatory");
                return;
            }


            con.Open();
            String query1 = "SELECT * FROM login_details WHERE username=@usr";
            SqlCommand cmd = new SqlCommand(query1, con);
            cmd.Parameters.AddWithValue("@usr", usr);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read()) {
                MessageBox.Show("Username already taken");
                con.Close();
                return;
            }
            con.Close();
            String query2 = "INSERT INTO login_details VALUES(COALESCE((SELECT MAX(lid)+1 FROM login_details), 1), @usr, @pass, 'staff')";
            con.Open();
            SqlCommand cmd2 = new SqlCommand(query2, con);
            cmd2.Parameters.AddWithValue("@usr", usr);
            cmd2.Parameters.AddWithValue("@pass", pass);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            con.Close();
            String query3 = "INSERT INTO staff VALUES(COALESCE((SELECT MAX(sid)+1 FROM staff), 1), @name, @dob, @gender, (SELECT lid FROM login_details where username=@usr), @address)";

            con.Open();
            SqlCommand cmd3 = new SqlCommand(query3, con);
            cmd3.Parameters.AddWithValue("@usr", usr);
            cmd3.Parameters.AddWithValue("@name", name);
            cmd3.Parameters.AddWithValue("@dob", dob);
            cmd3.Parameters.AddWithValue("gender", gender);
            cmd3.Parameters.AddWithValue("@address",address );
            SqlDataReader dr3 = cmd3.ExecuteReader();
            MessageBox.Show("staff added");
            con.Close();
        }
    }
}
