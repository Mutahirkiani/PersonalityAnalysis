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
    public partial class Form1 : Form

       
    {
        MySqlConnection connection;
        public Form1()
        {
            InitializeComponent();
            try
            {
                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
                builder.Server = "localhost";
                builder.UserID = "root";
                builder.Password = "33060";
                builder.Database = "carrental";
                connection = new MySqlConnection(builder.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            string Queryx = "delete from users where username='"+this.textBox1.Text+"';";

            MySqlCommand commandx = new MySqlCommand(Queryx,connection);
            MySqlDataReader dataReaderx;
            connection.Open();
            dataReaderx = commandx.ExecuteReader();
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form sign = new signup();
            sign.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(!(textBox1.Text.Length==0||textBox2.Text.Length==0))
           {
               try
               {
                   MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
                   builder.Server = "localhost";
                   builder.UserID = "root";
                   builder.Password = "33060";
                   builder.Database = "carrental";
                   connection = new MySqlConnection(builder.ToString());

               }
               catch (Exception ex) {
                   MessageBox.Show(ex.Message);
               }
                

           String login="select * from users where username= '"+this.textBox1.Text+"'and password='"+this.textBox2.Text+"';";
          
           MySqlCommand command = new MySqlCommand(login,connection);
           MySqlDataReader dataReader;
           connection.Open();
           dataReader = command.ExecuteReader();
           int count = 0;
           while (dataReader.Read())
           {
               count = count + 1;
           }
           if (count == 1)
           {
               Profilecs profile = new Profilecs(textBox1.Text);
               profile.Show();
               this.Hide();
           }
          else if (count > 1) {
               MessageBox.Show("Duplicate usrname and password");

           }
           else
               MessageBox.Show("username or password is not coreect please try again");
            }
            
           else{
                MessageBox.Show("All fields must be filled");
            }
           connection.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        }
    }
