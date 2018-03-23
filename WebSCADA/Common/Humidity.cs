using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    //Defining humidity sensor class

    [DataContract]
    public class Humidity
    {
        private string id;
        private double humValue;

        public Humidity(string id, double humValue)
        {
            this.id = id;
            this.humValue = humValue;
        }

        [DataMember]
        public string Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        [DataMember]
        public double HumValue
        {
            get { return this.humValue; }
            set { this.humValue = value; }
        }
    }
}
