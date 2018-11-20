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
    public partial class score : Form
    {
        string user;
        string pUser;
        MySqlConnection connection;
        string name;
        int count;
        public score(string userN, string PUserName, string Name, int countP)
        {
            InitializeComponent();
            user = userN;
            pUser = PUserName;
            name = Name;
            count = countP;
            label2.Text =""+ countP ;


            if (countP == 0) {
                label3.Text = "You know about " + Name+" is 0%";
            }
            else if (countP == 1)
            {
                label3.Text = "You know about " + Name + " is only 10%";
            }
            else if (countP == 2)
            {
                label3.Text = "You know about " + Name + " is only 20%";
            }
            else if (countP ==3)
            {
                label3.Text = "You know about " + Name + " is only 30%";
            }
            else if (countP == 4)
            {
                label3.Text = "You know about " + Name + " is 40%";
            }
            else if (countP == 5)
            {
                label3.Text = "You know about " + Name + " is 50%";
            }
            else if (countP == 6)
            {
                label3.Text = "You know about " + Name + " is 60%";
            }
            else if (countP == 7)
            {
                label3.Text = "You know about " + Name + " is 70%";
            }
            else if (countP == 8)
            {
                label3.Text = "You know about " + Name + " is 80%";
            }
            else if (countP == 9)
            {
                label3.Text = "You know about " + Name + " is 90%";
            }
            else if (countP == 10)
            {

                label3.Text = "You know about " + Name + " is 100%";
            }
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "33060";
            builder.Database = "carrental";
            connection = new MySqlConnection(builder.ToString());
            try
            {
                string query = "insert into score(username,attempteduser,result) values('" + user + "','" + PUserName + "','" + label2.Text + "')";

                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex) {
                MessageBox.Show("You already attempt the quiz of "+ Name+"So your score will not be updated");
            }
        }

        private void score_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Profilecs pF = new Profilecs(pUser);
            pF.Show();
            this.Hide();
        }
    }
}
