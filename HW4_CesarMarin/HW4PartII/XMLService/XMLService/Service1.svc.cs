using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;

namespace XMLService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public static string ver_output;
        public string VerifyXML(string ur_xml, string ur_xsd)
        {
            ver_output = "No error";
            
            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.Schemas.Add(null, ur_xsd);
                settings.ValidationType = ValidationType.Schema;
                settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
                settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
                settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
                settings.IgnoreWhitespace = true;

                XmlReader book = XmlReader.Create(ur_xml, settings);
                XmlDocument document = new XmlDocument();
                document.Load(book);

                ValidationEventHandler eventHandler = new ValidationEventHandler(validate);

                document.Validate(eventHandler);
                return "No Error";
            }
            catch (Exception err)
            {
                ver_output = "Error: " + err.Message;
                return ver_output;
            }
        }


        private static void validate(object sender, ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Warning)
                return;
            else // Error
                ver_output = " Error message" + e.Message;
        }

        public string XPathSearch(string ur_xml, string xpath_str)
        {
            string xp_output = "";
            XPathDocument dx = new XPathDocument(ur_xml);
            XPathNavigator nav = dx.CreateNavigator();
            XPathNodeIterator iterator = nav.Select(xpath_str);

            while (iterator.MoveNext())
            {
                xp_output += iterator.Current.Value + "<br>";
                
            }
            return xp_output;
        }
    }
}
