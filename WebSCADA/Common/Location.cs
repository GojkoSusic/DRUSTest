using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    //Defining location class

    [DataContract]
    public class Location
    {
        private int id;
        private string locationName;
        private double latitude;
        private double longitude;

        public Location(int id, string locationName, double latitude, double longitude)
        {
            this.id = id;
            this.locationName = locationName;
            this.latitude = latitude;
            this.longitude = longitude;
        }

        [DataMember]
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        [DataMember]
        public string LocationName
        {
            get { return this.locationName; }
            set { this.locationName = value; }
        }

        [DataMember]
        public double Latitude
        {
            get { return this.latitude; }
            set { this.latitude = value; }
        }

        [DataMember]
        public double Longitude
        {
            get { return this.longitude; }
            set { this.longitude = value; }
        }
    }
}
