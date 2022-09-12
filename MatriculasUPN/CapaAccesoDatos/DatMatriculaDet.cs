using MatriculasUPN.CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MatriculasUPN.CapaAccesoDatos
{
    public class DatMatriculaDet
    {
        #region singleton
        private static readonly DatMatriculaDet instancia = new DatMatriculaDet();
        public static DatMatriculaDet Instancia
        {
            get
            {
                return DatMatriculaDet.instancia;
            }
        }
        #endregion singleton
        #region methods
        public List<MatriculaDet> ListarMatriculaDet()
        {
            List<MatriculaDet> lista = new List<MatriculaDet>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                SqlCommand cmd = new SqlCommand("spListarMatriculaDet", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    MatriculaDet matriculaDet = new MatriculaDet
                    {

                        id = Convert.ToInt32(dr["id"]),
                        idClase = Convert.ToInt32(dr["idClase"]),
                        idMatricula = Convert.ToInt32(dr["idMatricula"]),
                        idPeriodo = Convert.ToInt32(dr["idPeriodo"]),
                    };

                    lista.Add(matriculaDet);
                }
                cn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return lista;
        }
        public List<MatriculaDet> BuscarMatriculaDet(int idMatricula)
        {
            List<MatriculaDet> lista = new List<MatriculaDet>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                SqlCommand cmd = new SqlCommand("spBuscarMatriculaDet", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@pmIdMatricula", idMatricula);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    MatriculaDet matriculaDet = new MatriculaDet
                    {

                        id = Convert.ToInt32(dr["id"]),
                        idClase = Convert.ToInt32(dr["idClase"]),
                        idMatricula = Convert.ToInt32(dr["idMatricula"]),
                        idPeriodo = Convert.ToInt32(dr["idPeriodo"]),
                    };

                    lista.Add(matriculaDet);
                }
                cn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return lista;
        }
        public MatriculaDet CrearMatriculaDet(MatriculaDet matriculaDet)
        {
            MatriculaDet matriculaDetNew = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                SqlCommand cmd = new SqlCommand("spCrearMatriculaDet", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@pmIdMatricula", matriculaDet.idMatricula);
                cmd.Parameters.AddWithValue("@pmIdClase", matriculaDet.idClase);
                cmd.Parameters.AddWithValue("@pmIdPeriodo", matriculaDet.idPeriodo);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    matriculaDetNew = new MatriculaDet
                    {
                        id = Convert.ToInt32(dr["id"]),
                    };
                }
                cn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return matriculaDetNew;
        }
        #endregion methods
        public Boolean EliminarClase(int idClase, int idMatricula, int idPeriodo)
        {
            Boolean flag = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                SqlCommand cmd = new SqlCommand("spEliminarClase", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@pmIdClase", idClase);
                cmd.Parameters.AddWithValue("@pmIdMatricula", idMatricula);
                cmd.Parameters.AddWithValue("@pmIdPeriodo", idPeriodo);
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
    }
}