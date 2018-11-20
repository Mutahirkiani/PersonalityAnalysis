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
    public partial class friendprofile : Form
    {
        string userName;
        string pUserName;
        MySqlConnection connection;
        string firstName;
        string name;
        string present;
        string present1;
        public friendprofile(string userN,string UserName)
        {
            InitializeComponent();
            userName = userN;
            pUserName = UserName;
            label2.Text = userName;
             MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
                builder.Server = "localhost";
                builder.UserID = "root";
                builder.Password = "33060";
                builder.Database = "carrental";
                connection = new MySqlConnection(builder.ToString());
                
                String login = "select firstname from users where username= '" + label2.Text + "';";

                MySqlCommand command = new MySqlCommand(login, connection);
                connection.Open();
                MySqlDataReader dataReader;
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {

                    firstName = dataReader.GetString("firstname");
                }
                connection.Close();
                String login1 = "select lastname from users where username= '" + label2.Text + "';";
                MySqlCommand command1 = new MySqlCommand(login1, connection);
                connection.Open();
                MySqlDataReader dataReader1;
                dataReader1 = command1.ExecuteReader();
                if (dataReader1.Read())
                {
                    name = firstName + " " + dataReader1.GetString("lastname");
                    label1.Text = name;
                }
                connection.Close();
              
                string query1 = "select tenthquestion from users where username= '" + label2.Text + "';";
                MySqlCommand command3 = new MySqlCommand(query1, connection);
                connection.Open();
                MySqlDataReader dataReader3;
                dataReader3 = command3.ExecuteReader();
                if (dataReader3.Read())
                {

                    present1 = dataReader3.GetString("tenthquestion");
                }

                else { }
        

                if (!((present1.Equals("Success")) || (present1.Equals("Family")) || (present1.Equals("Money")) || (present1.Equals("Happiness"))))
                {
                    button1.Text = "Quiz not created yet";
                    button1.Enabled = false;
                }
                else
                {

                    button1.Text = "Attemp quiz";
                }

            }
        private void friendprofile_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            firstQuestionAns fQA = new firstQuestionAns(userName, pUserName,name);
            fQA.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Profilecs p = new Profilecs(pUserName);
            p.Show();
            this.Hide();
        }
    }
}
