using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryIt
{
    public partial class TryItPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
      

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            XMLService.Service1Client xmlser = new XMLService.Service1Client();
            string ur_xml = TextBox1.Text;
            string query = TextBox3.Text;
            string query_return = xmlser.XPathSearch(ur_xml, query);
            Label3.Text = query_return;

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            XMLService.Service1Client xmlser = new XMLService.Service1Client();
            string ur_xml = TextBox1.Text;
            string ur_xsd = TextBox4.Text;
            string verify = xmlser.VerifyXML(ur_xml, ur_xsd);
            Label4.Text = verify;
        }
    }
}