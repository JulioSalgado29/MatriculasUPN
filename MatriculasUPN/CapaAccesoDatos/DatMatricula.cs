using MatriculasUPN.CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MatriculasUPN.CapaAccesoDatos
{
    public class DatMatricula
    {
        #region singleton
        private static readonly DatMatricula instancia = new DatMatricula();
        public static DatMatricula Instancia
        {
            get
            {
                return DatMatricula.instancia;
            }
        }
        #endregion singleton
        #region methods
        public List<Matricula> ListarMatricula()
        {
            List<Matricula> lista = new List<Matricula>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                SqlCommand cmd = new SqlCommand("spListarMatricula", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Estudiante student = new Estudiante();
                    Matricula matricula = new Matricula
                    {

                        id = Convert.ToInt32(dr["id"]),
                        code = Convert.ToString(dr["code"]),
                        dateCreation = Convert.ToDateTime(dr["dateCreation"]),
                        dateUpdate = Convert.ToDateTime(dr["dateUpdate"]),
                        idUsuario = Convert.ToInt32(dr["idUsuario"]),
                        idEstudiante= Convert.ToInt32(dr["idEstudiante"]),
                    };

                    lista.Add(matricula);
                }
                cn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return lista;
        }
        public Matricula VerificarMatricula(int idEstudiante)
        {
            Matricula matriculaNew = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                SqlCommand cmd = new SqlCommand("spVerificarMatricula", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@pmIdEstudiante", idEstudiante);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    matriculaNew = new Matricula
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
            return matriculaNew;
        }
        public Matricula CrearMatricula(Matricula matricula)
        {
            Matricula matriculaNew = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                SqlCommand cmd = new SqlCommand("spCrearMatricula", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@pmCode", matricula.code);
                cmd.Parameters.AddWithValue("@pmDateCreation", matricula.dateCreation);
                cmd.Parameters.AddWithValue("@pmDateUpdate", matricula.dateUpdate);
                cmd.Parameters.AddWithValue("@pmIdEstudiante", matricula.idEstudiante);
                cmd.Parameters.AddWithValue("@pmIdUsuario", matricula.idUsuario);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    matriculaNew = new Matricula
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
            return matriculaNew;
        }
        public Matricula ActualizarMatricula(Matricula matricula)
        {
            Matricula matriculaNew = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                SqlCommand cmd = new SqlCommand("spActualizarMatricula", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@pmCode", matricula.code);
                cmd.Parameters.AddWithValue("@pmDateUpdate", matricula.dateUpdate);
                cmd.Parameters.AddWithValue("@pmIdEstudiante", matricula.idEstudiante);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    matriculaNew = new Matricula
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
            return matriculaNew;
        }
        #endregion methods
    }
}