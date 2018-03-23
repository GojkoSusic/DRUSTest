using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    //Defining temperature sensor class

    [DataContract]
    public class Temperature
    {
        private string id;
        private double tempValue;

        public Temperature(string id, double temValue)
        {
            this.id = id;
            this.tempValue = temValue;
        }

        [DataMember]
        public string Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        [DataMember]
        public double TempValue
        {
            get { return this.tempValue; }
            set { this.tempValue = value; }
        }
    }
}
