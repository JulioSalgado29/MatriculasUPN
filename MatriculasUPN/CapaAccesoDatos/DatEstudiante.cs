using MatriculasUPN.CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MatriculasUPN.CapaAccesoDatos
{
    public class DatEstudiante
    {
        #region singleton
        private static readonly DatEstudiante instancia = new DatEstudiante();
        public static DatEstudiante Instancia
        {
            get
            {
                return DatEstudiante.instancia;
            }
        }
        #endregion singleton

        #region methods
        public List<Estudiante> ListarEstudiante()
        {
            List<Estudiante> lista = new List<Estudiante>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                SqlCommand cmd = new SqlCommand("spListarEstudiante", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Carrera carrera = new Carrera();
                    Estudiante student = new Estudiante
                    {

                        id = Convert.ToInt32(dr["id"]),
                        code = Convert.ToString(dr["code"]),
                        dateRegister = Convert.ToDateTime(dr["dateRegister"]),
                        state = Convert.ToBoolean(dr["state"]),

                        age = Convert.ToInt32(dr["age"]),
                        name = Convert.ToString(dr["name"]),
                        lastname = Convert.ToString(dr["lastname"]),

                    };
                    carrera.id = Convert.ToInt32(dr["idCarrera"]);
                    carrera.name = Convert.ToString(dr["nameCarrera"]);

                    student.carrera = carrera;

                    lista.Add(student);
                }
                cn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return lista;
        }
        
        public Estudiante BuscarEstudiante(int id)
        {
            Estudiante student = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                SqlCommand cmd = new SqlCommand("spBuscarEstudiante", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@pmId", id);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Carrera carrera = new Carrera();
                    student = new Estudiante
                    {
                        id = Convert.ToInt32(dr["id"]),
                        code = Convert.ToString(dr["code"]),
                        dateRegister = Convert.ToDateTime(dr["dateRegister"]),
                        state = Convert.ToBoolean(dr["state"]),

                        age = Convert.ToInt32(dr["age"]),
                        name = Convert.ToString(dr["name"]),
                        lastname = Convert.ToString(dr["lastname"]),
                    };
                    carrera.id = Convert.ToInt32(dr["idCarrera"]);
                    carrera.name = Convert.ToString(dr["nameCarrera"]);

                    student.carrera = carrera;
                }
                cn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return student;
        }
        public Boolean VerificarEstudiante(int id)
        {
            Boolean flag = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                SqlCommand cmd = new SqlCommand("spVerificarEstudiante", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@pmId", id);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    flag = Convert.ToBoolean(dr["state"]);
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