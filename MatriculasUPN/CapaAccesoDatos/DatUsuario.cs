using MatriculasUPN.CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MatriculasUPN.CapaAccesoDatos
{
    public class DatUsuario
    {
        #region singleton
        private static readonly DatUsuario instancia = new DatUsuario();
        public static DatUsuario Instancia
        {
            get
            {
                return DatUsuario.instancia;
            }
        }
        #endregion singleton

        #region methods
        public Usuario VerificarAcceso(String username, String password)
        {
            Usuario user = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                SqlCommand cmd = new SqlCommand("spVerificarAcceso", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@pmUsername", username);
                cmd.Parameters.AddWithValue("@pmPassword", password);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    user = new Usuario
                    {
                        id = Convert.ToInt32(dr["id"]),
                        email = Convert.ToString(dr["email"]),
                        username = username,

                        age = Convert.ToInt32(dr["age"]),
                        name = Convert.ToString(dr["name"]),
                        lastname = Convert.ToString(dr["lastname"]),
                    };
                }
                cn.Close();

            }
            catch (Exception e)
            {
                throw e;
            }
            return user;
        }
        public void AumentarIntentos(String username)
        {
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                SqlCommand cmd = new SqlCommand("spAumentarIntentos", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@pmUsername", username);
                cn.Open();
                cmd.ExecuteReader();
                cn.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int VerificarIntentos(String username)
        {
            int attemps = -1;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                SqlCommand cmd = new SqlCommand("spVerificarIntentos", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@pmUsername", username);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    attemps = Convert.ToInt32(dr["attemps"]);
                }
                cn.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return attemps;
        }
        public void ReiniciarIntentos(String username)
        {
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                SqlCommand cmd = new SqlCommand("spReiniciarIntentos", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@pmUsername", username);
                cn.Open();
                cmd.ExecuteReader();
                cn.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
    #endregion methods
}
