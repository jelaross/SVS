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
using System.Configuration;

namespace Secure_Voting_System
{

    public partial class Voter : Form
    {
        String USER = "";
        int VOTER_ID;
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["SQL_CONNECTION"]);

        public Voter(String username_from_login, int voterId)
        {

            InitializeComponent();

            new FloatingNotification(this, "bluejhfh");

            this.USER = username_from_login;
            this.VOTER_ID = voterId;

            lable_username.Text = username_from_login;
            fillcombo();
        }

        public void fillcombo()
        {
            DateTime date = DateTime.Now;
            string today = date.ToString("yyyy-MM-dd");
            string query = @"SELECT election_name FROM election 
                                WHERE eid NOT IN (SELECT eid from vote1 where vid=@vid) 
                                AND election_date=@today 
                                AND constituency=(SELECT constituency from voter where vid=@avid)";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            //MessageBox.Show(today+VOTER_ID);
            cmd.Parameters.AddWithValue("@today", today);
            cmd.Parameters.AddWithValue("@vid", VOTER_ID);
            cmd.Parameters.AddWithValue("@avid", VOTER_ID);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());

            }
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            con.Open();
            //String eidquery = "select eid from election where election_name=@election_name";
            //SqlCommand eidcmd = new SqlCommand(eidquery, con);
            //eidcmd.Parameters.AddWithValue("@election_name", comboBox1.Text);
            //SqlDataReader eiddata = eidcmd.ExecuteReader();
            //if (eiddata.Read())
            //{
            //    seleid = Convert.ToInt16(eiddata[0]);
            //}
            //else {
            //    new FloatingNotification(this,"Election Not Found");
            //    return;
            
            //}
            //eiddata.Close();

            //con.Open();
            //String vidquery = "select vid from voter where name=@name";
            //SqlCommand vidcmd = new SqlCommand(vidquery, con);
            //vidcmd.Parameters.AddWithValue("@name", USER);
            //SqlDataReader viddata = vidcmd.ExecuteReader();
            //if (viddata.Read())
            //{
            //    vid = Convert.ToInt16(viddata[0]);
            //}
            //else
            //{
            //    new FloatingNotification(this, "voter Not Found");
            //    return;

            //}
            //viddata.Close();

            string query = "select name,party,photo,symbol,cid from candidate where eid=(select eid from election where election_name=@election_name)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@election_name", comboBox1.Text);
            SqlDataReader data = cmd.ExecuteReader();
            //
            TableLayoutPanel table = tableLayoutPanel1;
            table.Visible = false;
            table.Controls.Clear();
            table.ColumnCount = 5;
            //table.RowCount = 20;
            int i = 0;
            while (data.Read())
            {
                Label name = new Label
                {
                    AutoSize = true,
                    Text = data[0].ToString(),
                    Font = new Font("Segoe UI", 12),
                    ForeColor = Color.White,
                    BackColor = Color.DarkGreen,
                    Padding = new Padding(10),

                };

                Label party = new Label
                {
                    AutoSize = true,
                    Text = data[1].ToString(),
                    Font = new Font("Segoe UI", 12),
                    ForeColor = Color.White,
                    BackColor = Color.DarkRed,
                    Padding = new Padding(10),

                };

                PictureBox symbol = new PictureBox
                {

                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = Image.FromFile(data[2].ToString()),
                };

                PictureBox photo = new PictureBox
                {

                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = Image.FromFile(data[3].ToString()),
                };

                Button btn = new Button
                {
                    Text = "VOTE",
                    Tag = data[4].ToString(),
                };
                btn.Click += (senderBtn, eBtn) => vote(senderBtn, eBtn);


                table.Controls.Add(name, 0, i);
                table.Controls.Add(party, 1, i);
                table.Controls.Add(symbol, 2, i);
                table.Controls.Add(photo, 3, i);
                table.Controls.Add(btn, 4, i);

                i++;

            }

            table.Visible = true;

            //fuck
            con.Close();

        }   
        public void vote(object sender, EventArgs e) 
        {
            int eid;

            con.Open();
            Button btn = sender as Button;
            int cid = Convert.ToInt32(btn.Tag.ToString());

            String eidquery = "select eid from election where election_name=@election_name";
            SqlCommand eidcmd = new SqlCommand(eidquery, con);
            eidcmd.Parameters.AddWithValue("@election_name", comboBox1.Text);
            SqlDataReader eiddata = eidcmd.ExecuteReader();
            if (eiddata.Read())
            {
                eid = Convert.ToInt16(eiddata[0]);
            }
            else
            {
                new FloatingNotification(this, "Election Not Found");
                return;

            }
            eiddata.Close();

            String query = "INSERT INTO vote1 VALUES(COALESCE((SELECT MAX(vote_id)+1 FROM vote1), 1), @vid, @eid, @cid)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@vid", VOTER_ID);
            cmd.Parameters.AddWithValue("@eid", eid);
            cmd.Parameters.AddWithValue("@cid", cid);
            SqlDataReader dr = cmd.ExecuteReader();
            con.Close();
           
            new FloatingNotification(panel1, "voted");
        }

        private void voter_shown(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
