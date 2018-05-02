using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    //Definition of class for subscription data
    [DataContract]    
    public class SubClientData
    {
        private List<string> ids;
        private  string clientId;

        [DataMember]
        public List<string> Ids
        {
            get { return this.ids; }
            set { this.ids = value; }
        }

        [DataMember]
        public string ClientId
        {
            get { return this.clientId; }
            set { this.clientId = value; }
        }
    }
}
