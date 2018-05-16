using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace loginPassService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public int loginId(int age)
        {
            Random rnd = new Random();
            int mul = rnd.Next(100, 201);
            return (age * mul);
        }

        public string password(string firstName, string lastName, int age)
        {
            string p1, p2, p3;
            p1 = lastName.Substring(0, 2);
            p2 = firstName.Substring(firstName.Length - 2, 2);
            p3 = Convert.ToString(age % 5);

            return p1 + p2 + p3;

        }
    }
}
