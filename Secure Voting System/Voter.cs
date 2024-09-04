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
using Secure_Voting_System.Properties;

namespace Secure_Voting_System
{

    public partial class Voter : Form
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-HVOUKVA; database=voting_system; Integrated Security=true");
        public Voter(String username_from_login)
        {
            InitializeComponent();
            fillcombo();
            lable_username.Text = username_from_login;


        }

        public void fillcombo()
        {
            string query = "select election_name from election";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());

            }
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "select name,party,photo,symbol,cid from candidate where eid=(select eid from election where election_name=@election_name)";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@election_name", comboBox1.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            new ottuPetti(tableLayoutPanel1, dr, 1, 7);
            con.Close();
           
        }

        private void Voter_Load(object sender, EventArgs e)
        {

        }
        public void vote(string cid) 
        { 
            
        
        
        }
    }
}
