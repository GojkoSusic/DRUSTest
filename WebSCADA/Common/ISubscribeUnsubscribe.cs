using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(INotifySubClient))]
    //Definition of subscribe unsubscribe interface
    public interface ISubscribeUnsubscribe
    {
        //Both methods return response message, and both can initiate a session
        [OperationContract(IsOneWay = false, IsInitiating = true)]
        void Subscribe(SubClientData data);
        [OperationContract(IsOneWay = false, IsInitiating = true)]
        void Unsubscribe();
    }
}
