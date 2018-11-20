using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace PersonalityAnalysis
{
    public partial class Profilecs : Form
    {
        MySqlConnection connection;
        string firstName;
        string name;
        string present;
        string pUserName;
        public Profilecs(string username)
        {

            try
            {
                InitializeComponent();
                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
                builder.Server = "localhost";
                builder.UserID = "root";
                builder.Password = "33060";
                builder.Database = "carrental";
                connection = new MySqlConnection(builder.ToString());
                pUserName = username;
                label2.Text = username;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                string query = "select tenthquestion from users where username= '" + label2.Text + "';";
                MySqlCommand command2 = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader dataReader2;
                dataReader2 = command2.ExecuteReader();
                if (dataReader2.Read())
                {

                    present = dataReader2.GetString("tenthquestion");
                }

            }
            catch (Exception e) { }
           
           //(present.Equals(null)){
              if (!((present.Equals("Success"))||(present.Equals("Family"))||(present.Equals("Money"))||(present.Equals("Happiness")))) {  

                    button1.Text="Create your quiz";
                }
                else {
                
                button1.Text="Edit your quiz";
                }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 back = new Form1();
            back.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            firstquestion first = new firstquestion(label2.Text, name);
            first.Show();
            this.Hide();
        }

        private void Profilecs_Load(object sender, EventArgs e)
        {

            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "33060";
            builder.Database = "carrental";
            connection = new MySqlConnection(builder.ToString());

            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            connection.Open();
            string sql = "select *from users";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                col.Add(sdr["username"].ToString());
            }
            sdr.Close();

            textBox1.AutoCompleteCustomSource = col;
            connection.Close();

        }

        private void textBox1_TextChanged(object sender,EventArgs e)
        {
            //MessageBox.Show("Text changed:" + textBox1.Text);
        }

        private void kD(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                friendprofile fP = new friendprofile(textBox1.Text,pUserName);
                fP.Show();
                this.Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            list listFriends = new list(pUserName);
            listFriends.Show();
            this.Hide();
        }
     

        
    }
}
