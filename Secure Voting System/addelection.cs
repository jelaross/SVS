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
    public partial class addelection : Form
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-HVOUKVA; database=voting_system; Integrated Security=true");
        public addelection()
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
                comboBox1.Items.Add(dr[0].ToString());
                
            }
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text==""){
                MessageBox.Show("Election name is mandatory");
                return;      
            }
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Select the consistuency");
                return;
            }
            String query = "INSERT INTO election VALUES(COALESCE((SELECT MAX(eid)+1 FROM election), 1), @elec_name, @const, @elec_date)";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@elec_name", textBox1.Text);
            cmd.Parameters.AddWithValue("@const", comboBox1.Text);
            cmd.Parameters.AddWithValue("@elec_date", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            int dr = cmd.ExecuteNonQuery();

            if(dr > 0){
                MessageBox.Show("election added successfully");
            
            
            }
        }
    }
}
