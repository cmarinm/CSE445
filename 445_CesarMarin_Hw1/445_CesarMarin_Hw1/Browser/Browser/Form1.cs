using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Browser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(txtUrl.Text);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            crypt.ServiceClient ende = new crypt.ServiceClient();
            string url = txtUrl.Text;
            label3.Text = ende.Encrypt(url);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            crypt.ServiceClient ende = new crypt.ServiceClient();
            string enc = label3.Text;
            label4.Text = ende.Decrypt(enc);
        }

        private string ver;
        private void button3_Click(object sender, EventArgs e)
        {
            image.ServiceClient verifier = new image.ServiceClient();
            ver = verifier.GetVerifierString("4");
            var source = verifier.GetImage(ver);
            var img = Bitmap.FromStream(source);
            pictureBox1.Image = img;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string usertext = textBox1.Text;
            if (usertext.Equals(ver))
                label5.Text = "correct";
            else
                label5.Text = "incorrect";

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
