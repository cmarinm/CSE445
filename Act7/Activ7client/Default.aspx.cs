using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Activ7client
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string firstName = TextBox1.Text;
            string lastName = TextBox2.Text;
            int age = Int32.Parse(TextBox3.Text);
            string passuri = @"http://localhost:53818/Service1.svc/passwd/" + firstName + "/" + lastName + "/" + age;
            string iduri = @"http://localhost:53818/Service1.svc/login/" + age;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(passuri);
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(responseStream);
            Label1.Text = reader.ReadToEnd();

            request = (HttpWebRequest)WebRequest.Create(iduri);
            response = request.GetResponse();
            responseStream = response.GetResponseStream();

            reader = new StreamReader(responseStream);
            Label2.Text = reader.ReadToEnd();


        }
    }
}