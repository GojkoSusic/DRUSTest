using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Common;
using System.Text;
using System.Threading.Tasks;

namespace MonitorClient1
{
    [CallbackBehaviorAttribute(UseSynchronizationContext =false)]
    //Implementing callback INotifySubClient interface
    class CallbackMethod : INotifySubClient
    {
        [OperationContract]
        public void Notify(string id, double value, bool flag)
        {
            if (flag)
            {
                Console.WriteLine("Current temperature value: {0} sensor id: {1}", value, id);
            }
            else
            {
                Console.WriteLine("Current humidity value: {0} sensor id: {1}", value, id);
            }
        }
    }
}
