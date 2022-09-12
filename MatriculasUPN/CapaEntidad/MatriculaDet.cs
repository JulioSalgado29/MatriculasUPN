using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatriculasUPN.CapaEntidad
{
    public class MatriculaDet
    {
        public int id { get; set; }
        public int idMatricula { get; set; }
        public int idClase { get; set; }
        public int idPeriodo { get; set; }

        public MatriculaDet(int idMatricula, int idClase, int idPeriodo)
        {
            this.idMatricula = idMatricula;
            this.idClase = idClase;
            this.idPeriodo = idPeriodo;
        }

        public MatriculaDet()
        {
        }
    }
}