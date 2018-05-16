using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

namespace LoginService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string createAccount(string eusr, string epsw, string efn, string eln, string eemail, string ephone, string eage, string ebday)
        {
            //pseudo for accoutn create
            // take encrypted user, decrypt, and check Login_db.txt for matching username
            //if found return username taken string. if not, username is valid
            // decrypt password, send to hash alg, turn hash to string, store username and password hash in Login_db.txt
            // Now, go to UsrInfo_db.txt and go to end(append)
            // Decrypt rest of data, turn to strings, store in order, every person element a new line
            // close files, send string succesful back.
            string filename = HttpContext.Current.Request.MapPath("Login_db.txt");
            StreamReader reader = new StreamReader(filename);
            string[] parse;
            string line = reader.ReadLine();
            while (line != null)
            {
                parse = line.Split();
                if (string.Equals(parse[0], eusr, StringComparison.OrdinalIgnoreCase))
                {
                    return "username taken";
                }
                line = reader.ReadLine();
            }
            // username not found in db so its valid.
            reader.Close();


            UInt64 hpsw = CalculateHash(epsw);
            string hashstring = hpsw.ToString();
            // Now write username hashstring to 
            string swrite = eusr + " " + hashstring;
            reader.Close();
            File.AppendAllText(filename, swrite + Environment.NewLine);
            // Now write to user info this info with username.
            string filename2 = HttpContext.Current.Request.MapPath("UsrInfo_db.txt");
            string userinfo = eusr + Environment.NewLine + efn + Environment.NewLine + eln + Environment.NewLine + eemail + Environment.NewLine + ephone + Environment.NewLine + eage + Environment.NewLine + ebday;
            File.AppendAllText(filename2, userinfo + Environment.NewLine);
            return "account creation succesful";
        }

 

        public string Login(string en_usr, string en_psw)
        {
            // decrypt both
            // send password to hash alg
            //get hash, turn into string
            // search Login_db.txt for username
            // check if hash stored with username is equal to this hash
            //if so, login succesful
            //now, go to UsrInfo_db.txt and look for username
            // get the next x lines for user data, create a response object from lines
            // serialize object to json string
            // encrypt json string and send back
            bool loginsuccess = false;
            UInt64 hpsw = CalculateHash(en_psw);
            string hashstring = hpsw.ToString();
            string filename = HttpContext.Current.Request.MapPath("Login_db.txt");
            StreamReader reader = new StreamReader(filename);
            string[] parse;
            string line = reader.ReadLine();
            while (line != null && !loginsuccess)
            {
                parse = line.Split();
                if (string.Equals(parse[0], en_usr, StringComparison.OrdinalIgnoreCase))
                {
                    
                    if (string.Equals(parse[1], hashstring))
                        loginsuccess = true;
                    // we found usr, lets see if hashtring matches
                }
                line = reader.ReadLine();
            }
            returnObject rtn = new returnObject();
            if (loginsuccess) rtn.loginsuccessful = "yes";
            else rtn.loginsuccessful = "no";
            rtn.firstName = "a";
            rtn.lastName = "a";
            rtn.email = "a";
            rtn.phone = "a";
            rtn.age = "a";
            rtn.bday = "a";
            if (loginsuccess)
            {
                string filename2 = HttpContext.Current.Request.MapPath("UsrInfo_db.txt");
                StreamReader ireader = new StreamReader(filename2);
                line = ireader.ReadLine();
                bool usrfound = false;
                while (line != null && !usrfound)
                {
                    if (string.Equals(line, en_usr, StringComparison.OrdinalIgnoreCase))
                    {
                        usrfound = true;
                        string fn = ireader.ReadLine();
                        string ln = ireader.ReadLine();
                        string email = ireader.ReadLine();
                        string phone = ireader.ReadLine();
                        string age = ireader.ReadLine();
                        string bday = ireader.ReadLine();
                        rtn.firstName = fn;
                        rtn.lastName = ln;
                        rtn.email = email;
                        rtn.phone = phone;
                        rtn.age = age;
                        rtn.bday = bday;
                        continue;
                    }
                    line = ireader.ReadLine();
                }
                if (!usrfound)
                {
                    rtn.loginsuccessful = "no";
                }
                ireader.Close();
            }
            reader.Close();
            
            string jsonresponse = JsonConvert.SerializeObject(rtn);
            return jsonresponse;
        }
        static UInt64 CalculateHash(string read)
        {
            UInt64 hashedValue = 3074457345618258791ul;
            for (int i = 0; i < read.Length; i++)
            {
                hashedValue += read[i];
                hashedValue *= 3074457345618258799ul;
            }
            return hashedValue;
        }

        public double bmi(string h, string w)
        {
            double he, we;
            we = Convert.ToDouble(w);
            he = Convert.ToDouble(h);

            double mid = we / he;
            return mid / he;
        }

        public double ftoc(string f)
        {
            double fa = Convert.ToDouble(f);
            return (fa - 32) / 1.8;
        }

        public double ctof(string c)
        {
            double ce = Convert.ToDouble(c);
            return ce * 1.8 + 32;
        }
    }
}
