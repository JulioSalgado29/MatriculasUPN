using MatriculasUPN.CapaAccesoDatos;
using MatriculasUPN.CapaLogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatriculasUPN.CapaLogica
{
    public class LogLogs
    {
        #region singleton
        private static readonly LogLogs instancia = new LogLogs();
        public static LogLogs Instancia
        {
            get
            {
                return instancia;
            }
        }
        #endregion singleton
        #region methods
        public Boolean CrearRegistroLog(LoginLogs loginLog)
        {
            return DatLogs.Instancia.CrearRegistroLog(loginLog);
        }
        public Boolean AgregarMovimiento(int idEstudiante)
        {
            return DatLogs.Instancia.AgregarMovimiento(idEstudiante);
        }
        public Boolean EliminarMovimiento(int idEstudiante)
        {
            return DatLogs.Instancia.EliminarMovimiento(idEstudiante);
        }
        public MatriculaLogs BuscarMatriculaLogs(int idEstudiante)
        {
            return DatLogs.Instancia.BuscarMatriculaLogs(idEstudiante);
        }
        #endregion methods
    }
}