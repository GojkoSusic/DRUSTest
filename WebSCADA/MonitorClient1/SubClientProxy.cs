using System;
using System.Collections.Generic;
using System.ServiceModel;
using Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorClient1
{
    //Implementation of ISubscribeUnsubscribe interface 
    //Implementation of generic class DuplexChannelFactory for opening channel toward server for subscribe and unsubscribe
    class SubClientProxy : DuplexChannelFactory<ISubscribeUnsubscribe>, ISubscribeUnsubscribe
    {
        ISubscribeUnsubscribe factory;

        public SubClientProxy(InstanceContext ic, string endpoint)
            : base(ic, endpoint)
        {
            factory = this.CreateChannel();
        }

        public void Subscribe(SubClientData data)
        {
            try
            {
                factory.Subscribe(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Unsubscribe()
        {
            try
            {
                factory.Unsubscribe();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
