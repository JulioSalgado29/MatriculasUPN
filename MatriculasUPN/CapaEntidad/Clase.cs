using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MatriculasUPN.CapaEntidad
{
    public class Clase
    {
        public int id { get; set; }
        public int idCurso { get; set; }
        public int idPeriodo { get; set; }
        [Display(Name = "Código de Clase")]
        public string code { get; set; }
        [Display(Name = "Hora de Inicio")]
        public DateTime ourBegin { get; set; }
        [Display(Name = "Hora de Fin")]
        public DateTime ourFinal { get; set; }
        [Display(Name = "Profesor")]
        public string teacher{ get; set; }
        [Display(Name = "Localidad")]
        public string location { get; set; }
        public Boolean state { get; set; }

        public Clase(int idCurso, int idPeriodo, string code, DateTime ourBegin, DateTime ourFinal, string teacher, string location)
        {
            this.idCurso = idCurso;
            this.code = code;
            this.ourBegin = ourBegin;
            this.ourFinal = ourFinal;
            this.teacher = teacher;
            this.location = location;
        }

        public Clase()
        {
        }
    }
}