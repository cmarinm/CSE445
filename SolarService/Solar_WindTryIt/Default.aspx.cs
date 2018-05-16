using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Solar_WindTryIt
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SolarService.Service1Client solar = new SolarService.Service1Client();
            WindService.Service1Client wind = new WindService.Service1Client();

            string in_lat, in_lon, solar_str, wind_str;
            int lat, lon;
            in_lat = TextBox1.Text;
            in_lon = TextBox2.Text;
            var format = new NumberFormatInfo();
            format.NegativeSign = "-";

            lat = Int32.Parse(in_lat, format);
            lon = Int32.Parse(in_lon, format);

            solar_str = solar.GetSolarIndex(lat, lon);
            wind_str = wind.GetWindIndex(lat, lon);
            Label2.Text = solar_str;
            Label1.Text = wind_str;

        }
    }
}