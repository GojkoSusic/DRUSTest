using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Common;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace MonitorClient1
{
    class Program
    {
        static void Main(string[] args)
        {

            InstanceContext context = new InstanceContext(new CallbackMethod());
            SubClientProxy proxy = new SubClientProxy(context, typeof(ISubscribeUnsubscribe).ToString());
            SubClientData data = new SubClientData();

            //Reading monitor client id from app config file
            data.ClientId = ConfigurationManager.AppSettings["Id"];

            //Waiting for monitor client to enter desired ids
            Console.WriteLine("Please enter id-s you want to subscribe (separeted by ,):");
            string input = Console.ReadLine();
            string[] ids = input.Split(',');
            data.Ids = ids.OfType<string>().ToList();

            //Subsrcibe for entered ids
            proxy.Subscribe(data);

            Console.ReadKey(true);

            proxy.Unsubscribe();

            Console.ReadKey(true);

        }
    }
}
