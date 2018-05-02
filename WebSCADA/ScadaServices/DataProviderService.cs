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

        private object lockThis = new object();
        public void SendTemperature(Temperature temperatureSensor, Location sensorLocation, string stationName)
        {
            string locationData = String.Format("Location: {0}, Latitude: {1}, Longitude: {2}, Statio name: {3}",
                                 sensorLocation.LocationName, sensorLocation.Latitude, sensorLocation.Longitude, stationName);
            string sensorData = String.Format("Temperature value: {0}, Sensor ID: {1}\n", temperatureSensor.TempValue, temperatureSensor.Id);

            Console.WriteLine(locationData);
            Console.WriteLine(sensorData);

            //This is critical section, lock keyword ensure that next thread can't enter critical section while another thread is
            //in critical section
            lock (lockThis)
            {
                //Check is there any subscribed client for current temperature sensor
                foreach (KeyValuePair<INotifySubClient, SubClientData> subs in PubSubService.subscribers)
                {
                    if (subs.Value.Ids.Contains(temperatureSensor.Id))
                    {
                        subs.Key.Notify(temperatureSensor.Id, temperatureSensor.TempValue, true);
                    }
                }
            }
            
        }

        //Accepting and displaying the humidity data
        public void SendHumidity(Humidity humiditySensor, Location sensorLocation, string stationName)
        {
            string locationData = String.Format("Location: {0}, Latitude: {1}, Longitude: {2}, Statio name: {3}", 
                                 sensorLocation.LocationName, sensorLocation.Latitude, sensorLocation.Longitude, stationName);
            string sensorData = String.Format("Humidity value: {0}, Sensor ID: {1}", humiditySensor.HumValue, humiditySensor.Id);

            Console.WriteLine(locationData);
            Console.WriteLine(sensorData);

            //This is critical section, lock keyword ensure that next thread can't enter critical section while another thread is
            //in critical section
            lock (lockThis)
            {
                //Check is there any subscribed client for current humidity sensor
                foreach (KeyValuePair<INotifySubClient, SubClientData> subs in PubSubService.subscribers)
                {
                    if (subs.Value.Ids.Contains(humiditySensor.Id))
                    {
                        subs.Key.Notify(humiditySensor.Id, humiditySensor.HumValue, false);
                    }
                }
            }
        }
        
    }
}
