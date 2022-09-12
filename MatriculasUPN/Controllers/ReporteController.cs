using MatriculasUPN.CapaEntidad;
using MatriculasUPN.CapaLogica;
using MatriculasUPN.CapaLogs;
using MatriculasUPN.CapaReportes;
using MatriculasUPN.Permisos;
using MatriculasUPN.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MatriculasUPN.Controllers
{
    public class ReporteController : Controller
    {
        [ValidarSesionActiva]
        public ActionResult Matriculas()
        {
            List<ReporteMatricula> matriculasReports = new List<ReporteMatricula>();
            List<Matricula> listaMatricula = LogReporte.Instancia.ListarMatricula();

            if (listaMatricula != null)
            {
                foreach (Matricula matricula in listaMatricula)
                {
                    ReporteMatricula reporteMatricula = new ReporteMatricula();
                    Estudiante estudiante = LogEstudiante.Instancia.BuscarEstudiante(matricula.idEstudiante);
                    List<Clase> listaClase = new List<Clase>();
                    List<Periodo> listaPeriodo = new List<Periodo>();
                    List<Curso> listaCurso = new List<Curso>();

                    List<MatriculaDet> listaMatriculaDet = LogReporte.Instancia.BuscarMatriculaDet(matricula.id);
                    foreach (MatriculaDet matriculaDet in listaMatriculaDet)
                    {
                        Clase clase = LogReporte.Instancia.BuscarClase(matriculaDet.idClase);
                        listaClase.Add(clase);
                        Periodo periodo = LogReporte.Instancia.BuscarPeriodo(clase.idPeriodo);
                        listaPeriodo.Add(periodo);
                    }
                    foreach (Clase clase in listaClase)
                    {
                        Curso curso = LogReporte.Instancia.BuscarCurso(clase.idCurso);
                        listaCurso.Add(curso);
                    }
                    MatriculaLogs matriculaLog = LogLogs.Instancia.BuscarMatriculaLogs(estudiante.id);

                    reporteMatricula.estudiante = estudiante;
                    reporteMatricula.clases = listaClase;
                    reporteMatricula.cursos = listaCurso;
                    reporteMatricula.periodos = listaPeriodo;
                    reporteMatricula.matriculaLog = matriculaLog;
                    matriculasReports.Add(reporteMatricula);
                }
                MatriculaReport matriculaReport = new MatriculaReport();
                byte[] abytes = matriculaReport.PrepararReportes(matriculasReports);
                return File(abytes, "application/pdf");
            }
            else
            {
                TempData["Message"] = "No existen se encuentra registrada ninguna matricula";
            }
            return View();
        }
    }
}