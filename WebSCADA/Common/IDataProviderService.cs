using System;
using System.ServiceModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    //Defining service contract interface for DataProviderService

    [ServiceContract]
    public interface IDataProviderService
    {
        [OperationContract]
        void SendTemperature(Temperature temperatureSensor, Location sensorLocation, string stationName);
        [OperationContract]
        void SendHumidity(Humidity humiditySensor, Location sensorLocation, string stationName);
    }
}
