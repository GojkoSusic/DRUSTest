using System;
using Common;
using System.Configuration;
using System.ServiceModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MeteoStationTrebinje
{
    class Program
    {
        //Reading metao station configuration data from configuration file

        private static string locationName = ConfigurationManager.AppSettings["LocationName"];
        private static double latitude = Double.Parse(ConfigurationManager.AppSettings["Latitude"]);
        private static double longitude = Double.Parse(ConfigurationManager.AppSettings["Longitude"]);
        private static string statioName = ConfigurationManager.AppSettings["MeteoStatioName"];
        private static string tempSensorId = ConfigurationManager.AppSettings["TemperatureSensorId"];
        private static string humSensorId = ConfigurationManager.AppSettings["HumiditySensorId"];

        static IDataProviderService sendDataProxy;
        static Random randomValue = new Random();
        static Location location = new Location(1, locationName, latitude, longitude);
        static void Main(string[] args)
        {
            ChannelFactory<IDataProviderService> dataChannelFactory = new ChannelFactory<IDataProviderService>(typeof(IDataProviderService).ToString());
            sendDataProxy = dataChannelFactory.CreateChannel();

            Console.WriteLine("Meteo station Trebinje sending the data...");

            Thread sendTemp = new Thread(SendTemperature);
            Thread sendHum = new Thread(SendHumidity);

            sendTemp.Start();
            sendHum.Start();

            Console.ReadKey(true);
        }

        private static void SendTemperature()
        {
            while (true)
            {
                double temValue = randomValue.Next(-35, 45);
                Temperature tempSensor = new Temperature(tempSensorId, temValue);
                sendDataProxy.SendTemperature(tempSensor, location, statioName);
                Thread.Sleep(1000);
            }
        }

        private static void SendHumidity()
        {
            while (true)
            {
                double humValue = randomValue.Next(0, 100);
                Humidity humSensor = new Humidity(humSensorId, humValue);
                sendDataProxy.SendHumidity(humSensor, location, statioName);
                Thread.Sleep(6000);
            }
        }
    }
}
