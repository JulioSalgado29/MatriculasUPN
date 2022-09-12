using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MatriculasUPN.CapaEntidad
{
    public class Curso
    {
        public int id { get; set; }
        [Display(Name = "Créditos")]
        public int credit { get; set; }
        [Display(Name = "Curso")]
        public string name { get; set; }
        [Display(Name = "Carrera")]
        public int idCarrera { get; set; }

        public Curso(int credit, string name, int idCarrera)
        {
            this.credit = credit;
            this.name = name;
            this.idCarrera = idCarrera;
        }

        public Curso()
        {
        }
    }
}