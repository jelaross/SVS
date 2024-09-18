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

            if (usr == "" || pass == "") {
                new FloatingNotification(this, "Please fill all fields", "#d33235");
            }

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
                        ElectionCommission elec_win = new ElectionCommission(dr[1].ToString());
                        elec_win.Show();
                        break;
                    case "staff":
                        staffdashboard staff_win = new staffdashboard(dr[1].ToString());
                        staff_win.Show();
                        break;
                    case "voter":
                        Voter voter_win = new Voter(dr[1].ToString());
                        voter_win.Show();
                        break;
                    default:

                        break;

                }


            }
            else {

                new FloatingNotification(this, "invalid login", "#d33235");
            }
            con.Close();


        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toggleEye(object sender, EventArgs e)
        {
            PictureBox obj = sender as PictureBox;
            if (textBox2.UseSystemPasswordChar == true)
            {
                textBox2.UseSystemPasswordChar = false;
                obj.Image = Secure_Voting_System.Properties.Resources.eyeClose;
            }
            else{
                textBox2.UseSystemPasswordChar = true;
                obj.Image = Secure_Voting_System.Properties.Resources.eye;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
