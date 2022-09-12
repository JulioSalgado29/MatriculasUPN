using MatriculasUPN.CapaAccesoDatos;
using MatriculasUPN.CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatriculasUPN.CapaLogica
{
    public class LogEstudiante
    {
        #region singleton
        private static readonly LogEstudiante instancia = new LogEstudiante();
        public static LogEstudiante Instancia
        {
            get
            {
                return instancia;
            }
        }
        #endregion singleton

        #region methods
        public List<Estudiante> ListarEstudiante()
        {
            List<Estudiante> lista = DatEstudiante.Instancia.ListarEstudiante();
            return lista;
        }

        public Estudiante BuscarEstudiante(int id)
        {
            return DatEstudiante.Instancia.BuscarEstudiante(id);
        }

        public Boolean VerificarEstudiante(int id)
        {
            return DatEstudiante.Instancia.VerificarEstudiante(id);
        }

        #endregion methods
    }
}