using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MatriculasUPN.CapaEntidad
{
    public class Persona
    {
        [Display(Name = "Nombre")]
        public string name { get; set; }
        [Display(Name = "Apellido")]
        public string lastname { get; set; }
        [Display(Name = "Edad")]
        public int age { get; set; }

        public Persona(string name, string lastname, int age)
        {
            this.name = name;
            this.lastname = lastname;
            this.age = age;
        }

        public Persona()
        {
        }

        public string GetNames()
        {
            return name + ' ' + lastname;
        }

    }
}