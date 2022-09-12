using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatriculasUPN.CapaEntidad
{
    public class Periodo
    {
        public int id { get; set; }
        public int age { get; set; }
        public string type { get; set; }
        public string name { get; set; }


        public Periodo(int age, string type)
        {
            this.age = age;
            this.type = type;
        }

        public Periodo()
        {
        }
    }
}