using MatriculasUPN.CapaAccesoDatos;
using MatriculasUPN.CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatriculasUPN.CapaLogica
{
    public class LogReporte
    {
        #region singleton
        private static readonly LogReporte instancia = new LogReporte();
        public static LogReporte Instancia
        {
            get
            {
                return instancia;
            }
        }
        #endregion singleton
        #region methods
        public List<Matricula> ListarMatricula()
        {
            List<Matricula> lista = DatMatricula.Instancia.ListarMatricula();
            return lista;
        }
        public List<MatriculaDet> BuscarMatriculaDet(int idMatricula)
        {
            return DatMatriculaDet.Instancia.BuscarMatriculaDet(idMatricula);
        }
        public Clase BuscarClase(int id)
        {
            return DatClase.Instancia.BuscarClase(id);
        }
        public Curso BuscarCurso(int id)
        {
            return DatCurso.Instancia.BuscarCurso(id);
        }
        public Periodo BuscarPeriodo(int id)
        {
            return DatPeriodo.Instancia.BuscarPeriodo(id);
        }
        #endregion methods
    }
}