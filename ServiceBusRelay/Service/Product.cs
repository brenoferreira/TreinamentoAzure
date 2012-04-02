using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Service
{
    [DataContract]
    public class Product
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public String Name { get; set; }

        [DataMember]
        public float Price { get; set; }
    }
}
