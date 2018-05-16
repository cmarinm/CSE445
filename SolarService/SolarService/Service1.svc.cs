using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Newtonsoft.Json;

namespace SolarService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetSolarIndex(int lat, int lon)
        {
            // solar api url: https://developer.nrel.gov/api/solar/solar_resource/v1.json?api_key=DEMO_KEY&lat=40&lon=-105
            // my key: KBcJqSTpP4xRTWHzAh8x1NtONuW0iH6ga8REz93N
            string output = "";
            string uri = @"https://developer.nrel.gov/api/solar/solar_resource/v1.json?api_key=KBcJqSTpP4xRTWHzAh8x1NtONuW0iH6ga8REz93N"
            + "&lat=" + lat.ToString() + "&lon=" + lon.ToString();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(responseStream);
            String res = reader.ReadToEnd();
            try
            {
                RootObject solarser = JsonConvert.DeserializeObject<RootObject>(res);
                string annualdni = solarser.outputs.avg_dni.annual.ToString();
                output = "The annual DNI for Lat =" + lat.ToString() + " Lon =" + lon.ToString() + " is " + annualdni
                + "kW/m^2/day";
            } catch (JsonSerializationException)
            {
                output = "There is no data for this location";

            }
            

            return output;
        }



        public class Metadata
        {
            public List<string> sources { get; set; }
        }

        public class Inputs
        {
            public string api_key { get; set; }
            public string lat { get; set; }
            public string lon { get; set; }
        }

        public class Monthly
        {
            public double jan { get; set; }
            public double feb { get; set; }
            public double mar { get; set; }
            public double apr { get; set; }
            public double may { get; set; }
            public double jun { get; set; }
            public double jul { get; set; }
            public double aug { get; set; }
            public double sep { get; set; }
            public double oct { get; set; }
            public double nov { get; set; }
            public double dec { get; set; }
        }

        public class AvgDni
        {
            public double annual { get; set; }
            public Monthly monthly { get; set; }
        }

        public class Monthly2
        {
            public double jan { get; set; }
            public double feb { get; set; }
            public double mar { get; set; }
            public double apr { get; set; }
            public double may { get; set; }
            public double jun { get; set; }
            public double jul { get; set; }
            public double aug { get; set; }
            public double sep { get; set; }
            public double oct { get; set; }
            public double nov { get; set; }
            public double dec { get; set; }
        }

        public class AvgGhi
        {
            public double annual { get; set; }
            public Monthly2 monthly { get; set; }
        }

        public class Monthly3
        {
            public double jan { get; set; }
            public double feb { get; set; }
            public double mar { get; set; }
            public double apr { get; set; }
            public double may { get; set; }
            public double jun { get; set; }
            public double jul { get; set; }
            public double aug { get; set; }
            public double sep { get; set; }
            public double oct { get; set; }
            public double nov { get; set; }
            public double dec { get; set; }
        }

        public class AvgLatTilt
        {
            public double annual { get; set; }
            public Monthly3 monthly { get; set; }
        }

        public class Outputs
        {
            public AvgDni avg_dni { get; set; }
            public AvgGhi avg_ghi { get; set; }
            public AvgLatTilt avg_lat_tilt { get; set; }
        }

        public class RootObject
        {
            public string version { get; set; }
            public List<object> warnings { get; set; }
            public List<object> errors { get; set; }
            public Metadata metadata { get; set; }
            public Inputs inputs { get; set; }
            public Outputs outputs { get; set; }
        }
    }
}
