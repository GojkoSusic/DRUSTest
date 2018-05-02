using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    //Definition of callback interface(to notify subscribed monitor client)
    [ServiceContract]
    public interface INotifySubClient
    {
        //This methos does not return reply message
        [OperationContract(IsOneWay =true)]
        void Notify(string id, double value, bool flag);
    }
}
