using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace PersonalityAnalysis
{
    public partial class eightquestion : Form
    {
        string user;
        string name;
        MySqlConnection connection;
        string firstQ;
        public eightquestion(string userName, string Name)
        {
            InitializeComponent();
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;
            user = userName;
            name = Name;
            label1.Text = "About future" + name + " is?";
            
        }

        private void eightquestion_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                firstQ = radioButton1.Text;

            }
            else if (radioButton2.Checked == true)
            {
                firstQ = radioButton2.Text;

            }
            else if (radioButton3.Checked == true)
            {
                firstQ = radioButton3.Text;

            }
            else if (radioButton5.Checked == true)
            {
                firstQ = radioButton5.Text;

            }

            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "33060";
            builder.Database = "carrental";
            connection = new MySqlConnection(builder.ToString());

            string fQ = "update users set eightquestion='" + firstQ + "'where username='" + user + "'";
            MySqlCommand command = new MySqlCommand(fQ, connection);
            connection.Open();
            MySqlDataReader dataReader;
            dataReader = command.ExecuteReader();
            ninthquestion second = new ninthquestion(user, name);
            second.Show();
            this.Hide();
        }
    }
}
