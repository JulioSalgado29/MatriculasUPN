using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MatriculasUPN.CapaEntidad
{
    public class Estudiante : Persona
    {
        public int id { get; set; }

        [Display(Name = "Código")]
        public string code { get; set; }
        [Display(Name = "Fecha de Registro")]
        public DateTime dateRegister { get; set; }
        [Display(Name = "Estado")]
        public Boolean state { get; set; }
        public int idCarrera { get; set; }

        [Display(Name = "Carrera")]
        public Carrera carrera { get; set; }

        public Estudiante(string code, DateTime dateRegister, bool state, int idCarrera)
        {
            this.code = code;
            this.dateRegister = dateRegister;
            this.state = state;
            this.idCarrera = idCarrera;
        }

        public Estudiante()
        {
        }
    }
}