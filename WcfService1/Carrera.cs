using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService1
{
    [DataContract]
    public class Carrera
    {
        [DataMember ]

        public int id_carrera { get; set; }

        [DataMember]

        public string carrera { get; set; }

        
    }
}