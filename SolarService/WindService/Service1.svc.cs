using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WindService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetWindIndex(int lat, int lon)
        {
            // parse winddata.txt to find matching lat and lon
            // when found parse in the annual average, send back as string
            string line;
            string output ="";
            string []parse;
            int p_lat, p_lon;
            double p_annual =0.0;
            bool found = false;
            StreamReader reader = new StreamReader("WindData.txt");
            line = reader.ReadLine(); // ignore first line
            line = reader.ReadLine();
            while(line != null && !found)
            {
                parse = line.Split();
                p_lat = Convert.ToInt32(parse[0]);
                p_lon = Convert.ToInt32(parse[1]);
                if (p_lat == lat && p_lon == lon)
                {
                    p_annual = Convert.ToDouble(parse[14]);
                    found = true;
                    continue;
                }
                line = reader.ReadLine();

            }

            if (!found)
            {
                output = "Lat or Lon did not match";
            }
            else
            {
                output = "The annual wind index for Lat =" + lat.ToString() + " and Lon =" + lon.ToString()
                    + " is  " + p_annual.ToString() + "m/s";
            }


            return output;
        }
    }
}
