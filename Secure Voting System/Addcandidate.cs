using System;
using System.IO;
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

    public partial class Addcandidate : Form
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-HVOUKVA; database=voting_system; Integrated Security=true");
        public Addcandidate()
        {
            InitializeComponent();
            fillcombo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {

                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                Title = "Select an Image"
            };


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                pictureBox1.Image = System.Drawing.Image.FromFile(openFileDialog.FileName);
                textBox6.Text = openFileDialog.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {

                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                Title = "Select an Image"
            };


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                pictureBox2.Image = System.Drawing.Image.FromFile(openFileDialog.FileName);
                textBox7.Text = openFileDialog.FileName;
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            String election_name, name, party, photo_path, symbol_path;
            election_name = comboBox1.Text;
            name = textBox3.Text;
            party = textBox4.Text;
            photo_path = textBox6.Text;
            symbol_path = textBox7.Text;

            if (name == "")
            {
                new FloatingNotification(this, "name is mandatory", "#d33235");
                return;
            }

            if (election_name == "")
            {
                new FloatingNotification(this, "election name is mandatory", "#d33235");
                return;
            }

            if (party == "")
            {
                new FloatingNotification(this, "party is mandatory", "#d33235");
                return;
            }

            if (photo_path == "")
            {
                new FloatingNotification(this, "photo is mandatory", "#d33235");
                return;
            }
            if (symbol_path == "")
            {
                new FloatingNotification(this, "symbol is mandatory", "#d33235");
                return;
            }


            string destination_photo_path = @"E:\Secure Voting System\pic_path\" + Path.GetFileNameWithoutExtension(photo_path) + Path.GetExtension(photo_path);
            string destination_symbol_path = @"E:\Secure Voting System\pic_path\" + Path.GetFileNameWithoutExtension(symbol_path) + Path.GetExtension(symbol_path);
            int counter = 1;
            while (File.Exists(destination_photo_path) || File.Exists(destination_symbol_path))
            {
                destination_photo_path = @"E:\Secure Voting System\pic_path\" + Path.GetFileNameWithoutExtension(photo_path) + counter + Path.GetExtension(photo_path);
                destination_symbol_path = @"E:\Secure Voting System\pic_path\" + Path.GetFileNameWithoutExtension(symbol_path) + counter + Path.GetExtension(symbol_path);
                counter++;
            }

            try
            {
                //File.Copy(photo_path, destination_photo_path, overwrite: true);
                //File.Copy(symbol_path, destination_symbol_path, overwrite: true);
                //new FloatingNotification(this, "File copied successfully.");

                ImageResizer.ResizeImage(photo_path, destination_photo_path, 100, 100);
                ImageResizer.ResizeImage(symbol_path, destination_symbol_path, 100, 100);
            }
            catch (IOException ex)
            {
                Console.WriteLine("An error occurred while copying the file: " + ex.Message);
                new FloatingNotification(this, "Cant copy Photo", "#d33235");
                return;
            }
            String query = "INSERT INTO candidate (cid,eid,name,photo,symbol,party) VALUES(COALESCE((SELECT MAX(cid)+1 FROM candidate), 1), (SELECT eid FROM election where election_name=@election_name), @name, @photo, @symbol, @party)";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@election_name", election_name);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@photo", destination_photo_path);
            cmd.Parameters.AddWithValue("@symbol", destination_symbol_path);
            cmd.Parameters.AddWithValue("@party", party);
            SqlDataReader dr = cmd.ExecuteReader();
            //textBox3.Text = "";
            //textBox4.Text = "";
            //textBox6.Text = "";
            //textBox7.Text = "";
            //pictureBox1.Image = null;
            //pictureBox2.Image = null;
            new FloatingNotification(this, "Candidate Added", "#41a45d");
            con.Close();

        }

        private void Addcandidate_Load(object sender, EventArgs e)
        {

        }
    }
}
