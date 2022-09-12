using MatriculasUPN.CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MatriculasUPN.CapaAccesoDatos
{
    public class DatPeriodo
    {
        #region singleton
        private static readonly DatPeriodo instancia = new DatPeriodo();
        public static DatPeriodo Instancia
        {
            get
            {
                return DatPeriodo.instancia;
            }
        }
        #endregion singleton
        #region methods
        public List<Periodo> ListarPeriodo()
        {
            List<Periodo> lista = new List<Periodo>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                SqlCommand cmd = new SqlCommand("spListarPeriodo", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Periodo period = new Periodo
                    {
                        id = Convert.ToInt32(dr["id"]),
                        name = Convert.ToString(dr["name"]),
                    };

                    lista.Add(period);

                }
                cn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return lista;
        }
        public Periodo BuscarPeriodo(int id)
        {
            Periodo period = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                SqlCommand cmd = new SqlCommand("spBuscarPeriodo", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@pmId", id);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    period = new Periodo
                    {
                        id = Convert.ToInt32(dr["id"]),
                        name = Convert.ToString(dr["name"]),
                    };
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            return period;
        }
        public Boolean VerificarPeriodo(int id)
        {
            Boolean flag = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                SqlCommand cmd = new SqlCommand("spVerificarPeriodo", cn)
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
        #endregion methods
    }
}