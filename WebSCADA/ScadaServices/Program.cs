using System;
using System.ServiceModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaServices
{
    class Program
    {
        //Defining and opening Service to accept incoming data
        //Defining and opening Service for subscribe and unsubscribe for monitor clinets
        private static ServiceHost dataProviderService = null;
        private static ServiceHost subUnsubService = null;
        static void Main(string[] args)
        {
            dataProviderService = new ServiceHost(typeof(DataProviderService));
            subUnsubService = new ServiceHost(typeof(PubSubService));
            dataProviderService.Open();
            subUnsubService.Open();

            Console.WriteLine("SCADA server is running...");
            Console.ReadKey();
            dataProviderService.Close();
            subUnsubService.Close();
        }
    }
}
