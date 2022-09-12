using MatriculasUPN.CapaAccesoDatos;
using MatriculasUPN.CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatriculasUPN.CapaLogica
{
    public class LogMatricula
    {
        #region singleton
        private static readonly LogMatricula instancia = new LogMatricula();
        public static LogMatricula Instancia
        {
            get
            {
                return instancia;
            }
        }
        #endregion singleton
        public List<Periodo> ListarPeriodo()
        {
            List<Periodo> lista = DatPeriodo.Instancia.ListarPeriodo();
            return lista;
        }
        public Periodo BuscarPeriodo(int id)
        {
            Periodo periodo = DatPeriodo.Instancia.BuscarPeriodo(id);
            return periodo;
        }
        public Boolean VerificarPeriodo(int id)
        {
            return DatPeriodo.Instancia.VerificarPeriodo(id);
        }
        public List<Curso> ListarCurso(int idCarrera)
        {
            List<Curso> lista = DatCurso.Instancia.ListarCurso(idCarrera);
            return lista;
        }
        public Curso BuscarCurso(int id)
        {
            Curso curso = DatCurso.Instancia.BuscarCurso(id);
            return curso;
        }
        public Boolean VerificarCurso(int id)
        {
            return DatCurso.Instancia.VerificarCurso(id);
        }
        public List<Clase> ListarClase(int idCurso, int idPeriodo)
        {
            List<Clase> lista = DatClase.Instancia.ListarClase(idCurso, idPeriodo);
            return lista;
        }
        public Clase BuscarClase(int id)
        {
            return DatClase.Instancia.BuscarClase(id);
        }
        public Boolean VerificarClase(int id)
        {
            return DatClase.Instancia.VerificarClase(id);
        }
        public List<Clase> ListarClasesDelEstudiante(int idEstudiante, int idPeriodo)
        {
            return DatClase.Instancia.ListarClasesDelEstudiante(idEstudiante, idPeriodo);
        }
        public List<Curso> ListarCursosDelEstudiante(int idEstudiante, int idPeriodo)
        {
            return DatCurso.Instancia.ListarCursosDelEstudiante(idEstudiante, idPeriodo);
        }
        public Matricula VerificarMatricula(int idEstudiante)
        {
            return DatMatricula.Instancia.VerificarMatricula(idEstudiante);
        }
        public Matricula CrearMatricula(Matricula matricula)
        {
            return DatMatricula.Instancia.CrearMatricula(matricula);
        }
        public MatriculaDet CrearMatriculaDet(MatriculaDet matriculaDet)
        {
            return DatMatriculaDet.Instancia.CrearMatriculaDet(matriculaDet);
        }
        public Boolean EliminarClase(int idClase, int idMatricula, int idPeriodo)
        {
            return DatMatriculaDet.Instancia.EliminarClase(idClase, idMatricula, idPeriodo);
        }
    }
}