using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatriculasUPN.CapaEntidad
{
    public class Matricula
    {
        public int id { get; set; }
        public string code { get; set; }
        public DateTime dateCreation { get; set; }
        public DateTime dateUpdate { get; set; }
        public int idEstudiante { get; set; }
        public int idUsuario { get; set; }

        public Matricula(string code, DateTime dateCreation, DateTime dateUpdate, int idEstudiante, int idUsuario)
        {
            this.code = code;
            this.dateCreation = dateCreation;
            this.dateUpdate = dateUpdate;
            this.idEstudiante = idEstudiante;
            this.idUsuario = idUsuario;
        }

        public Matricula()
        {
        }
    }
}