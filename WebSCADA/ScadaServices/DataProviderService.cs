using System;
using Common;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ScadaServices
{
    //Implementation of IDataProviderService contract

    //Accepting and displaying the temperature data
    public class DataProviderService : IDataProviderService
    {
        public void SendTemperature(Temperature temperatureSensor, Location sensorLocation, string stationName)
        {
            string locationData = String.Format("Location: {0}, Latitude: {1}, Longitude: {2}, Statio name: {3}",
                                 sensorLocation.LocationName, sensorLocation.Latitude, sensorLocation.Longitude, stationName);
            string sensorData = String.Format("Temperature value: {0}, Sensor ID: {1}\n", temperatureSensor.TempValue, temperatureSensor.Id);

            Console.WriteLine(locationData);
            Console.WriteLine(sensorData);
            
        }

        //Accepting and displaying the humidity data
        public void SendHumidity(Humidity humiditySensor, Location sensorLocation, string stationName)
        {
            string locationData = String.Format("Location: {0}, Latitude: {1}, Longitude: {2}, Statio name: {3}", 
                                 sensorLocation.LocationName, sensorLocation.Latitude, sensorLocation.Longitude, stationName);
            string sensorData = String.Format("Humidity value: {0}, Sensor ID: {1}", humiditySensor.HumValue, humiditySensor.Id);

            Console.WriteLine(locationData);
            Console.WriteLine(sensorData);
        }
        
    }
}
