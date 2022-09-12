using MatriculasUPN.CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatriculasUPN.CapaLogs
{
    public class MatriculaLogs
    {
        public Estudiante estudiante { get; set; }
        public int movimientoAgregacion { get; set; }
        public int movimientoEliminacion { get; set; }

        public MatriculaLogs(Estudiante estudiante, int movimientoAgregacion, int movimientoEliminacion)
        {
            this.estudiante = estudiante;
            this.movimientoAgregacion = movimientoAgregacion;
            this.movimientoEliminacion = movimientoEliminacion;
        }
        public MatriculaLogs()
        {
        }
        public string getMovimientos()
        {
            return "Se realizaron un total de " + movimientoAgregacion + " movimientos de agregación \n" +
                "Se realizaron un total de " + movimientoEliminacion + " movimientos de eliminacion";
        }
    }
}