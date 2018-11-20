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
    public partial class signup : Form
    {
        public signup()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(!(textBox1.Text.Length==0||textBox2.Text.Length==0||textBox3.Text.Length==0||textBox4.Text.Length==0))
            {
                try
                {
                    MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
                    builder.Server ="localhost";
                    builder.UserID = "root";
                    builder.Password = "33060";
                    builder.Database = "carrental";

                    MySqlConnection connection = new MySqlConnection(builder.ToString());



                    string newuser_sql = "insert into users(username,password,firstname,lastname,firstquestion,secondquestion,thirdquestion,forthquestion,fifthquestion,sixthquestion,seventhquestion,eightquestion,ninthquestion,tenthquestion )  values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "')";

            

                    MySqlCommand command = new MySqlCommand(newuser_sql, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    Form1 f = new Form1();
                    f.Show();
                    this.Hide();

                }
                catch(Exception ex){
                    MessageBox.Show(ex.Message);
                    //MessageBox.Show("username already use by another user please try anothr username", "Error", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
                }
            }
            else{
                MessageBox.Show("All fields must be filled");
            }
        }

        private void signup_Load(object sender, EventArgs e)
        {

        }
    }
}
