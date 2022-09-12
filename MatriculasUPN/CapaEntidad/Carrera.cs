using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatriculasUPN.CapaEntidad
{
    public class Carrera
    {
        public int id { get; set; }
        public string name { get; set; }

        public Carrera(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public Carrera()
        {
        }
    }
}