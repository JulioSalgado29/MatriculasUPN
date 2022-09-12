using MatriculasUPN.CapaEntidad;
using MatriculasUPN.CapaLogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatriculasUPN.CapaReportes
{
    public class ReporteMatricula
    {
        public Estudiante estudiante { get; set; }
        public List<Clase> clases { get; set; }
        public List<Periodo> periodos { get; set; }
        public List<Curso> cursos { get; set; }
        public MatriculaLogs matriculaLog { get; set; }

        public string getClases()
        {
            string frase = "";
            for(int i=0; i<clases.Count(); i++)
            {
                frase += clases[i].code + "\n";
                if(i == clases.Count())
                {
                    frase += clases[i].code;
                }
            }
            return frase;
        }

        public string getCursos()
        {
            string frase = "";
            for (int i = 0; i < cursos.Count(); i++)
            {
                frase += cursos[i].name + "\n";
                if (i == cursos.Count())
                {
                    frase += cursos[i].name;
                }
            }
            return frase;
        }

        public int getCantidadCursos()
        {
            return cursos.Count();
        }
        public string getPeriodos()
        {
            string frase = "";
            for (int i = 0; i < periodos.Count(); i++)
            {
                frase += periodos[i].name + "\n";
                if (i == periodos.Count())
                {
                    frase += periodos[i].name;
                }
            }
            return frase;
        }
    }
}