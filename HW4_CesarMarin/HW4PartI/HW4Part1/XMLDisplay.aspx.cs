using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace HW4Part1
{
    public partial class XMLDisplay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string output;
        protected void Button1_Click(object sender, EventArgs e)
        {
            string file = TextBox1.Text;
            XmlDocument doc = new XmlDocument();
            doc.Load(file);
            XmlNode root = doc.DocumentElement;
            Label1.Text = "";
            generateOutput(root);
        }

        public void generateOutput(XmlNode node)
        {
            if (node == null)
                return;

            Label1.Text += "Type=" + node.NodeType + "    " + "Name=" + node.Name +"    "+ "Content=" + node.Value + "<br>";
            if (node.HasChildNodes)
            {
                XmlNodeList children = node.ChildNodes;
                foreach (XmlNode child in children)
                    generateOutput(child);
            }
        }
    }
}