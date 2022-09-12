using MatriculasUPN.CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MatriculasUPN.CapaAccesoDatos
{
    public class DatClase
    {
        #region singleton
        private static readonly DatClase instancia = new DatClase();
        public static DatClase Instancia
        {
            get
            {
                return DatClase.instancia;
            }
        }
        #endregion singleton
        #region methods
        public List<Clase> ListarClase(int idCurso, int idPeriodo)
        {
            List<Clase> lista = new List<Clase>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                SqlCommand cmd = new SqlCommand("spListarClase", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@pmIdCurso", idCurso);
                cmd.Parameters.AddWithValue("@pmIdPeriodo", idPeriodo);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Clase clase = new Clase
                    {
                        id = Convert.ToInt32(dr["id"]),
                        idCurso = Convert.ToInt32(dr["idCurso"]),
                        idPeriodo = Convert.ToInt32(dr["idPeriodo"]),
                        code = Convert.ToString(dr["code"]),
                        ourBegin = Convert.ToDateTime(dr["ourBegin"]),
                        ourFinal = Convert.ToDateTime(dr["ourFinal"]),
                        teacher = Convert.ToString(dr["teacher"]),
                        location = Convert.ToString(dr["location"]),
                    };

                    lista.Add(clase);
                }
                cn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return lista;
        }
        public Clase BuscarClase(int id)
        {
            Clase clase = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                SqlCommand cmd = new SqlCommand("spBuscarClase", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@pmId", id);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    clase = new Clase
                    {
                        id = Convert.ToInt32(dr["id"]),
                        idCurso = Convert.ToInt32(dr["idCurso"]),
                        idPeriodo = Convert.ToInt32(dr["idPeriodo"]),
                        code = Convert.ToString(dr["code"]),
                        ourBegin = Convert.ToDateTime(dr["ourBegin"]),
                        ourFinal = Convert.ToDateTime(dr["ourFinal"]),
                        teacher = Convert.ToString(dr["teacher"]),
                        location = Convert.ToString(dr["location"]),
                    };
                }
                cn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return clase;
        }
        public Boolean VerificarClase(int id)
        {
            Boolean flag = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                SqlCommand cmd = new SqlCommand("spBuscarClase", cn)
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
        public List<Clase> ListarClasesDelEstudiante(int idEstudiante, int idPeriodo)
        {
            List<Clase> lista = new List<Clase>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                SqlCommand cmd = new SqlCommand("spListarClasesDelEstudiante", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@pmIdEstudiante", idEstudiante);
                cmd.Parameters.AddWithValue("@pmIdPeriodo", idPeriodo);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Clase clase = new Clase
                    {
                        id = Convert.ToInt32(dr["id"]),
                        idCurso = Convert.ToInt32(dr["idCurso"]),
                        idPeriodo = Convert.ToInt32(dr["idPeriodo"]),
                        code = Convert.ToString(dr["code"]),
                        ourBegin = Convert.ToDateTime(dr["ourBegin"]),
                        ourFinal = Convert.ToDateTime(dr["ourFinal"]),
                        teacher = Convert.ToString(dr["teacher"]),
                        location = Convert.ToString(dr["location"]),
                        state = Convert.ToBoolean(dr["state"]),
                    };

                    lista.Add(clase);
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