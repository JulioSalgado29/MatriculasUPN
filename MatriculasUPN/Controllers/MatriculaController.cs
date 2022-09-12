using MatriculasUPN.CapaEntidad;
using MatriculasUPN.CapaLogica;
using MatriculasUPN.CapaLogs;
using MatriculasUPN.Permisos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace MatriculasUPN.Controllers
{
    [ValidarSesionActiva]
    public class MatriculaController : Controller
    {
        [HttpGet]
        public ActionResult Index(int idEstudiante)
        {
            if (LogEstudiante.Instancia.VerificarEstudiante(idEstudiante))
            {
                Estudiante estudiante = LogEstudiante.Instancia.BuscarEstudiante(idEstudiante);
                List<Periodo> listaPeriodo = LogMatricula.Instancia.ListarPeriodo();

                ViewBag.listaPeriodo = new SelectList(listaPeriodo, "id", "name");
                return View(estudiante);
            }
            return RedirectToAction("ListaEstudiantes", "Estudiante");
        }

        [HttpPost]
        public ActionResult Index(int idEstudiante, FormCollection frm)
        {
            try
            {
                var idPeriodo = Convert.ToInt32(frm["cboPeriodo"]);
                if (LogEstudiante.Instancia.VerificarEstudiante(idEstudiante) &&
                    LogMatricula.Instancia.VerificarPeriodo(idPeriodo)
                        )
                {
                    return RedirectToAction("Cursos", "Matricula", new { idEstudiante, idPeriodo });
                }
            }
            catch
            {
                TempData["Message"] = "Debe seleccionar un periodo disponible";
            }
            return RedirectToAction("Index", "Matricula", new { idEstudiante = idEstudiante });
        }
        [HttpGet]
        public ActionResult Cursos(int idEstudiante, int idPeriodo)
        {
            if (LogEstudiante.Instancia.VerificarEstudiante(idEstudiante) &&
                LogMatricula.Instancia.VerificarPeriodo(idPeriodo))
            {
                Estudiante estudiante = LogEstudiante.Instancia.BuscarEstudiante(idEstudiante);
                Periodo periodo = LogMatricula.Instancia.BuscarPeriodo(idPeriodo);
                List<Curso> listaCurso = LogMatricula.Instancia.ListarCurso(estudiante.carrera.id);
                ViewData["estudiante"] = estudiante;
                ViewData["periodo"] = periodo;

                return View(listaCurso);
            }
            return RedirectToAction("ListaEstudiantes", "Estudiante");
        }
        [HttpGet]
        public ActionResult Clases(int idEstudiante, int idPeriodo, int idCurso)
        {
            if (LogEstudiante.Instancia.VerificarEstudiante(idEstudiante) &&
                LogMatricula.Instancia.VerificarPeriodo(idPeriodo) &&
                LogMatricula.Instancia.VerificarCurso(idCurso))
            {
                Estudiante estudiante = LogEstudiante.Instancia.BuscarEstudiante(idEstudiante);
                Periodo periodo = LogMatricula.Instancia.BuscarPeriodo(idPeriodo);
                Curso curso = LogMatricula.Instancia.BuscarCurso(idCurso);
                List<Clase> listaClase = LogMatricula.Instancia.ListarClase(idCurso, idPeriodo);
                List<Clase> listaClaseEstudiante = LogMatricula.Instancia.ListarClasesDelEstudiante(estudiante.id, idPeriodo);

                for (int i = 0; i < listaClase.Count(); i++)
                {
                    for (int j = 0; j < listaClaseEstudiante.Count(); j++)
                    {
                        if (listaClase[i].id == listaClaseEstudiante[j].id)
                        {
                            listaClase[i] = listaClaseEstudiante[j];
                        }
                    }
                }
                Console.WriteLine("Debug");

                ViewData["estudiante"] = estudiante;
                ViewData["periodo"] = periodo;
                ViewData["curso"] = curso;

                return View(listaClase);
            }
            return RedirectToAction("ListaEstudiantes", "Estudiante");
        }

        [HttpGet]
        public ActionResult InscribirClase(int idEstudiante, int idPeriodo, int idCurso, int idClase)
        {
            if (LogEstudiante.Instancia.VerificarEstudiante(idEstudiante) &&
                LogMatricula.Instancia.VerificarPeriodo(idPeriodo) &&
                LogMatricula.Instancia.VerificarCurso(idCurso) &&
                LogMatricula.Instancia.VerificarClase(idClase))
            {
                Estudiante estudiante = LogEstudiante.Instancia.BuscarEstudiante(idEstudiante);
                Periodo periodo = LogMatricula.Instancia.BuscarPeriodo(idPeriodo);
                Curso curso = LogMatricula.Instancia.BuscarCurso(idCurso);
                Matricula matricula = LogMatricula.Instancia.VerificarMatricula(estudiante.id);

                //Actualizar matricula
                if (matricula != null)
                {
                    //Verficacion de cursos
                    List<Curso> listaCursoEstudiante = LogMatricula.Instancia.ListarCursosDelEstudiante(estudiante.id, idPeriodo);
                    Boolean flag = false;
                    int i = 0;
                    while (i < listaCursoEstudiante.Count() && !flag)
                    {
                        if (listaCursoEstudiante[i].id == curso.id)
                        {
                            flag = true;
                        }
                        i++;
                    }
                    if (!flag)
                    {
                        MatriculaDet matriculaDet = new MatriculaDet();
                        matriculaDet.idClase = idClase;
                        matriculaDet.idMatricula = matricula.id;
                        matriculaDet.idPeriodo = periodo.id;
                        LogMatricula.Instancia.CrearMatriculaDet(matriculaDet);
                        //AGREGACIÓN
                        LogLogs.Instancia.AgregarMovimiento(estudiante.id);
                        TempData["MessageSuccess"] = "Clase registrada con éxito";
                        return RedirectToAction("Clases", "Matricula", new { idEstudiante = idEstudiante, idPeriodo = idPeriodo, idCurso = idCurso });
                    }
                    else
                    {
                        TempData["MessageError"] = "La clase no se pudo registrar porque el estudiante ya se encuentra en una clase de este curso";
                        return RedirectToAction("Clases", "Matricula", new { idEstudiante = idEstudiante, idPeriodo = idPeriodo, idCurso = idCurso });
                    }
                }
                else
                {
                    DateTime dateTime = DateTime.Now;
                    Matricula matriculaNew = new Matricula();
                    matriculaNew.code = estudiante.code + "-" + estudiante.name + "-" + estudiante.carrera;
                    matriculaNew.dateCreation = dateTime;
                    matriculaNew.dateUpdate = dateTime;
                    matriculaNew.idEstudiante = idEstudiante;
                    matriculaNew.idUsuario = Convert.ToInt32(Session["idUsuario"]);

                    matriculaNew = LogMatricula.Instancia.CrearMatricula(matriculaNew);

                    MatriculaDet matriculaDetNew = new MatriculaDet();
                    matriculaDetNew.idClase = idClase;
                    matriculaDetNew.idMatricula = matriculaNew.id;
                    matriculaDetNew.idPeriodo = idPeriodo;
                    LogMatricula.Instancia.CrearMatriculaDet(matriculaDetNew);
                    //AGREGACIÓN
                    LogLogs.Instancia.AgregarMovimiento(estudiante.id);
                    TempData["MessageSuccess"] = "Clase registrada con éxito";
                    return RedirectToAction("Clases", "Matricula", new { idEstudiante = idEstudiante, idPeriodo = idPeriodo, idCurso = idCurso });
                }
            }
            return RedirectToAction("ListaEstudiantes", "Estudiante");
        }
        [HttpGet]
        public ActionResult EliminarClase(int idEstudiante, int idPeriodo, int idCurso, int idClase)
        {
            if (LogEstudiante.Instancia.VerificarEstudiante(idEstudiante) &&
                LogMatricula.Instancia.VerificarPeriodo(idPeriodo) &&
                LogMatricula.Instancia.VerificarCurso(idCurso) &&
                LogMatricula.Instancia.VerificarClase(idClase))
            {
                Matricula matricula = LogMatricula.Instancia.VerificarMatricula(idEstudiante);
                LogMatricula.Instancia.EliminarClase(idClase, matricula.id, idPeriodo);
                //AGREGACIÓN
                LogLogs.Instancia.EliminarMovimiento(idEstudiante);
                TempData["MessageSuccess"] = "Clase eliminada con éxito";
                return RedirectToAction("Clases", "Matricula", new { idEstudiante = idEstudiante, idPeriodo = idPeriodo, idCurso = idCurso });
            }
            else
            {
                return RedirectToAction("ListaEstudiantes", "Estudiante");
            }
        }
    }
}