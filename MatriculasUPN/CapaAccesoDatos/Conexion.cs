using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MatriculasUPN.CapaAccesoDatos
{
    public class Conexion
    {
        #region singleton
        private static readonly Conexion UnicaInstancia = new Conexion();
        public static Conexion Instancia
        {
            get
            {
                return Conexion.UnicaInstancia;
            }
        }
        #endregion singleton

        #region methods
        public SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection
            {
                ConnectionString = "Data Source=LAPTOP-0JRQJ414\\SQLEXPRESS; Initial Catalog=UniversidadUPN;" + "Integrated Security=true"
            };
            return cn;
        }
        #endregion methods
    }
}