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
    public partial class list : Form
    {
        List<string> listFriends = new List<string>();
        List<int> listScore = new List<int>();
        MySqlConnection connection;
        string user;
        public list(string userName)
        {
            InitializeComponent();
            user = userName;
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "33060";
            builder.Database = "carrental";
            connection = new MySqlConnection(builder.ToString());
           
            String login = "select attempteduser from score where username= '" + userName + "';";
            MySqlCommand command = new MySqlCommand(login, connection);
            connection.Open();
            MySqlDataReader dataReader;
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                listFriends.Add(dataReader.GetString("attempteduser"));
            }
           
            listBox1.DataSource = listFriends;
            connection.Close();
            String login1 = "select result from score where username= '" + userName + "';";

            MySqlCommand command1 = new MySqlCommand(login1, connection);
            connection.Open();
            MySqlDataReader dataReader1;
            dataReader1 = command1.ExecuteReader();
            while (dataReader1.Read())
            {
                listScore.Add(dataReader1.GetInt16("result"));
            }
            listBox2.DataSource = listScore;

        }

        private void list_Load(object sender, EventArgs e)
        {

        }

        private void list_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart c = new chart(listFriends,listScore);
            c.Show();
    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            line l = new line(listFriends, listScore);
            l.Show();
          

        }

        private void button3_Click(object sender, EventArgs e)
        {
            pie p = new pie(listFriends, listScore);
            p.Show();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            chart1 c1 = new chart1(listFriends, listScore);
            c1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Profilecs p = new Profilecs(user);
            p.Show();
            this.Hide();
        }
      
    }
}
