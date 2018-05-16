using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loginAppClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lpservice.Service1Client client = new lpservice.Service1Client();
            string firstName = textBox1.Text;
            string lastName = textBox2.Text;
            int age = Int32.Parse(textBox3.Text);

            int id = client.loginId(age);
            string password = client.password(firstName, lastName, age);

            label7.Text = id.ToString();
            label8.Text = password;


        }
    }
}
