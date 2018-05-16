using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string eusr = TextBox2.Text;
            string epsw = TextBox3.Text;
            string efn = TextBox1.Text;
            string eln = TextBox4.Text;
            string eemail = TextBox5.Text;
            string ephone = TextBox6.Text;
            string eage = TextBox7.Text;
            string ebday = TextBox8.Text;
            ///{eusr}/{epsw}/{efn}/{eln}/{eemail}/{ephone}/{eage}/{ebday}"
            string url = @"http://webstrar11.fulton.asu.edu/Page8/Service1.svc/createAccount/" + eusr + "/" + epsw + "/" + efn + "/" + eln
                 + "/" + eemail + "/" + ephone + "/" + eage + "/" + ebday;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(responseStream);
            String output = reader.ReadToEnd();
            Label1.Text = output;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
        // Log in

        ///Login/{en_usr}/{en_psw}"
        string eusr = TextBox9.Text;
            string epsw = TextBox10.Text;
            
            string url = @"http://webstrar11.fulton.asu.edu/Page8/Service1.svc/Login/" + eusr + "/" + epsw;
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
           // WebResponse response = request.GetResponse();
           // Stream responseStream = response.GetResponseStream();

           // StreamReader reader = new StreamReader(responseStream);
           // string json = reader.ReadToEnd();
            WebClient wc = new WebClient();
            string json2 = wc.DownloadString(url);
            Label2.Text = json2;


            /*if (info.loginsuccessful == 0)
            {
                Label2.Text = "Login Not Successful";
            }
            else
            {
                Label2.Text = "Login Success!";
                Label3.Text = info.firstName;
                Label4.Text = info.lastName;
                Label5.Text = info.email;
                Label6.Text = info.phone;
                Label7.Text = info.age;
                Label8.Text = info.bday;
            } */

        }
        public class RootObject
        {

            public int loginsuccessful { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string email { get; set; }
            public string phone { get; set; }
            public string age { get; set; }
            public string bday { get; set; }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string f = TextBox11.Text;
            string url = @"http://webstrar11.fulton.asu.edu/Page8/Service1.svc/ftoc/" + f;
            WebClient wc = new WebClient();
            string result = wc.DownloadString(url);
            TextBox12.Text = result;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string c = TextBox12.Text;
            string url = @"http://webstrar11.fulton.asu.edu/Page8/Service1.svc/ctof/" + c;
            WebClient wc = new WebClient();
            string result = wc.DownloadString(url);
            TextBox11.Text = result;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            SolarService.Service1Client solar = new SolarService.Service1Client();


            string in_lat, in_lon, solar_str, wind_str;
            int lat, lon;
            in_lat = TextBox13.Text;
            in_lon = TextBox14.Text;
            var format = new NumberFormatInfo();
            format.NegativeSign = "-";

            lat = Int32.Parse(in_lat, format);
            lon = Int32.Parse(in_lon, format);

            solar_str = solar.GetSolarIndex(lat, lon);
            wind_str = solar.GetWindIndex(lat, lon);
            Label3.Text = solar_str;
            Label4.Text = wind_str;
        }
    }
}