using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LoginService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebGet(
        UriTemplate = "/Login/{en_usr}/{en_psw}")]
        string Login(string en_usr, string en_psw);

        [OperationContract]
        [WebGet(
        UriTemplate = "/createAccount/{eusr}/{epsw}/{efn}/{eln}/{eemail}/{ephone}/{eage}/{ebday}")]
        string createAccount(string eusr, string epsw, string efn, string eln, string eemail, string ephone, string eage, string ebday);

        [OperationContract]
        [WebGet(UriTemplate = "/ftoc/{f}", ResponseFormat = WebMessageFormat.Json)]
        double ftoc(string f);

        [OperationContract]
        [WebGet(UriTemplate = "/ctof/{c}", ResponseFormat =WebMessageFormat.Json)]
        double ctof(string c);
        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    
    [DataContract]
    public class returnObject
    {
        [DataMember]
        public string loginsuccessful;

        [DataMember]
        public string firstName;

        [DataMember]
        public string lastName;

        [DataMember]
        public string email;

        [DataMember]
        public string phone;

        [DataMember]
        public string age;

        [DataMember]
        public string bday;

    }
}
