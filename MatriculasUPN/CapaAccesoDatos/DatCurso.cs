using MatriculasUPN.CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MatriculasUPN.CapaAccesoDatos
{
    public class DatCurso
    {
        #region singleton
        private static readonly DatCurso instancia = new DatCurso();
        public static DatCurso Instancia
        {
            get
            {
                return DatCurso.instancia;
            }
        }
        #endregion singleton
        #region methods
        public List<Curso> ListarCurso(int idCarrera)
        {
            List<Curso> lista = new List<Curso>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                SqlCommand cmd = new SqlCommand("spListarCurso", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@pmIdCarrera", idCarrera);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Curso course = new Curso
                    {
                        id = Convert.ToInt32(dr["id"]),
                        name = Convert.ToString(dr["name"]),
                        credit = Convert.ToInt32(dr["credit"]),
                        idCarrera = Convert.ToInt32(dr["idCarrera"]),
                    };

                    lista.Add(course);
                }
                cn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return lista;
        }
        public Curso BuscarCurso(int id)
        {
            Curso course = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                SqlCommand cmd = new SqlCommand("spBuscarCurso", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@pmId", id);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    course = new Curso
                    {
                        id = Convert.ToInt32(dr["id"]),
                        name = Convert.ToString(dr["name"]),
                        credit = Convert.ToInt32(dr["credit"]),
                        idCarrera = Convert.ToInt32(dr["idCarrera"]),
                    };
                }
                cn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return course;
        }
        public Boolean VerificarCurso(int id)
        {
            Boolean flag = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                SqlCommand cmd = new SqlCommand("spVerificarCurso", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@pmId", id);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    flag = true;
                }
                cn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return flag;
        }
        public List<Curso> ListarCursosDelEstudiante(int idEstudiante, int idPeriodo)
        {
            List<Curso> lista = new List<Curso>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                SqlCommand cmd = new SqlCommand("spListarCursosDelEstudiante", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@pmIdEstudiante", idEstudiante);
                cmd.Parameters.AddWithValue("@pmIdPeriodo", idPeriodo);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Curso course = new Curso
                    {
                        id = Convert.ToInt32(dr["id"]),
                        name = Convert.ToString(dr["name"]),
                        credit = Convert.ToInt32(dr["credit"]),
                        idCarrera = Convert.ToInt32(dr["idCarrera"]),
                    };

                    lista.Add(course);
                }
                cn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return lista;
        }
        #endregion methods
    }
}