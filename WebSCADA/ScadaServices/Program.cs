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
        private static ServiceHost dataProviderService = null;
        static void Main(string[] args)
        {
            dataProviderService = new ServiceHost(typeof(DataProviderService));
            dataProviderService.Open();

            Console.WriteLine("SCADA server is running...");
            Console.ReadKey();
            dataProviderService.Close();
        }
    }
}
