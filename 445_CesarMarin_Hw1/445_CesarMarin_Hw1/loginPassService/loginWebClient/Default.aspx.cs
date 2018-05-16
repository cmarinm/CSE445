using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace loginWebClient
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            logpservice.Service1Client client = new logpservice.Service1Client();
            string firstName = TextBox1.Text;
            string lastName = TextBox2.Text;
            int age = Int32.Parse(TextBox3.Text);

            int id = client.loginId(age);
            string password = client.password(firstName, lastName, age);

            Label1.Text = id.ToString();
            Label2.Text = password;

        }
    }
}