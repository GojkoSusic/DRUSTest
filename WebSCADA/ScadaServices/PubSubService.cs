using System;
using Common;
using System.ServiceModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaServices
{
    //Implementig the ISubscribeUnsubscribe interface
    //All subscribed clients are stored in 'subscribers' dictionary
    public class PubSubService : ISubscribeUnsubscribe
    {
        INotifySubClient ServiceCallback = null;
        public static Dictionary<INotifySubClient, SubClientData> subscribers = new Dictionary<INotifySubClient, SubClientData>();
        public void Subscribe(SubClientData data)
        {
            //Obtaining the callback channel and add subscriber to dictionary
            ServiceCallback = OperationContext.Current.GetCallbackChannel<INotifySubClient>();
            subscribers.Add(ServiceCallback,data);
            Console.WriteLine("Subscribed");
        }

        public void Unsubscribe()
        {
            //Obtaining the callback channel and remove subscriber from dictionary
            ServiceCallback = OperationContext.Current.GetCallbackChannel<INotifySubClient>();
            subscribers.Remove(ServiceCallback);
            Console.WriteLine("Unsubscribed");
        }
    }
}
