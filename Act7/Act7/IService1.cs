using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Act7
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebGet ( UriTemplate = "/passwd/{firstName}/{lastName}/{age}")]
        string password(string firstName, string lastName, string age);

        [OperationContract]
        [WebGet (UriTemplate = "/login/{age}")]
        int loginId(string age);

        // TODO: Add your service operations here
    }


   
}
