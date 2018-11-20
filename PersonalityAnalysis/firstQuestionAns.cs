﻿using System;
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
    public partial class firstQuestionAns : Form
    {
        string user;
        string pUser;
        string firstQ;
        MySqlConnection connection;
        string name;
        string ans;
        int count=0;
        int count1;

        public firstQuestionAns(string userN, string PUserName,string Name)
        {
            InitializeComponent();
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;
            user = userN;
            pUser = PUserName;
            name = Name;
            label1.Text = "What kind of person " + name + " is?";
        }

        private void firstQuestionAns_Load(object sender, EventArgs e)
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

            String login = "select firstquestion from users where username= '" + user + "';";
            MySqlCommand command = new MySqlCommand(login, connection);
            connection.Open();
            MySqlDataReader dataReader;
            dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {

                ans = dataReader.GetString("firstquestion");
            }
            if (firstQ.Equals(ans))
            {
                count = count + 1;
                secondquestionans sQA = new secondquestionans(user, pUser, name, count);
                sQA.Show();
                this.Hide();
            }
            else {
                count1 = count;
                secondquestionans sQA = new secondquestionans(user, pUser, name, count1);
                sQA.Show();
                this.Hide();
            }

        }
    }
}