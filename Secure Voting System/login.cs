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
    public partial class login : Form
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-HVOUKVA; database=voting_system; Integrated Security=true");
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String usr, pass, query;
            usr = textBox1.Text;
            pass = textBox2.Text;
            con.Open();

            query = "SELECT * FROM login_details WHERE username=@user AND password=@pass";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@user", usr);
            cmd.Parameters.AddWithValue("@pass", pass);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                switch (dr[3].ToString())
                {

                    case "commissioner":
                        ElectionCommission elec_win = new ElectionCommission();
                        elec_win.Show();
                        break;
                    case "staff":
                        staffdashboard staff_win = new staffdashboard();
                        staff_win.Show();
                        break;
                    case "voter":
                        staffdashboard voter_win = new staffdashboard();
                        voter_win.Show();
                        break;
                    default:

                        break;

                }


            }
            else {

                MessageBox.Show("invalid login");
            }
            con.Close();


        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
