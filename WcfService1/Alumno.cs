using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService1
{
    [DataContract]
    public class Alumno
    {
        [DataMember]

        public int id_alumno { get; set; }

        [DataMember]

        public string name { get; set; }

        [DataMember]

        public string  a_paterno { get; set; }

        [DataMember]

        public string a_materno { get; set; }

        [DataMember]

        public int edad { get; set; }

        [DataMember]

        public Carrera id_carrera { get; set; }
    }
}