using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PersonalityAnalysis
{
    public partial class success : Form
    {
        string user;
        string name;
        public success(string userName, string Name)
        {
            InitializeComponent();
            user = userName;
            name = Name;
        }

        private void success_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Profilecs pro = new Profilecs(user);
            pro.Show();
            this.Hide();

        }
    }
}
