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
using System.Configuration;

namespace Secure_Voting_System
{
    public partial class login : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["SQL_CONNECTION"]);
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

            query = @"select login_details.usertype, login_details.lid, voter.vid, staff.sid , staff.name as staff_name, voter.name as voter_name_name from login_details 
	                    FULL OUTER JOIN staff on staff.lid=login_details.lid
	                    FULL OUTER JOIN voter on voter.lid=login_details.lid
	                    Where login_details.username=@username AND login_details.password=@pass";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", usr);
            cmd.Parameters.AddWithValue("@pass", pass);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                switch (dr[0].ToString())
                {

                    case "commissioner":
                        ElectionCommission elec_win = new ElectionCommission("commisioner");
                        elec_win.Show();
                        break;
                    case "staff":
                        staffdashboard staff_win = new staffdashboard(dr[4].ToString());
                        staff_win.Show();
                        break;
                    case "voter":
                        Voter voter_win = new Voter(dr[5].ToString(), Convert.ToInt32(dr[2]));
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
