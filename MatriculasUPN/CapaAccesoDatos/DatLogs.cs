using MatriculasUPN.CapaEntidad;
using MatriculasUPN.CapaLogs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MatriculasUPN.CapaAccesoDatos
{
    public class DatLogs
    {
        #region singleton
        private static readonly DatLogs instancia = new DatLogs();
        public static DatLogs Instancia
        {
            get
            {
                return DatLogs.instancia;
            }
        }
        #endregion singleton
        #region methods
        public Boolean CrearRegistroLog(LoginLogs loginLog)
        {
            Boolean flag = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                SqlCommand cmd = new SqlCommand("spCrearRegistroLog", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@pmIdUsuario", loginLog.usuario.id);
                cmd.Parameters.AddWithValue("@pmFechaIngreso", loginLog.fechaIngreso);
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
        public Boolean AgregarMovimiento(int idEstudiante)
        {
            Boolean flag = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                SqlCommand cmd = new SqlCommand("spAgregarMovimiento", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@pmIdEstudiante", idEstudiante);
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
        public Boolean EliminarMovimiento(int idEstudiante)
        {
            Boolean flag = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                SqlCommand cmd = new SqlCommand("spEliminarMovimiento", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@pmIdEstudiante", idEstudiante);
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
        public MatriculaLogs BuscarMatriculaLogs(int idEstudiante)
        {
            MatriculaLogs matriculaLog = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                SqlCommand cmd = new SqlCommand("spBuscarMatriculaLogs", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@pmIdEstudiante", idEstudiante);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    matriculaLog = new MatriculaLogs
                    {
                        movimientoAgregacion = Convert.ToInt32(dr["movimientoAgregacion"]),
                        movimientoEliminacion = Convert.ToInt32(dr["movimientoEliminacion"]),
                    };
                }
                cn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return matriculaLog;
        }
        #endregion methods
    }
}