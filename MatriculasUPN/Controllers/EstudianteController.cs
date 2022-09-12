using MatriculasUPN.CapaEntidad;
using MatriculasUPN.CapaLogica;
using MatriculasUPN.Permisos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MatriculasUPN.Controllers
{
    [ValidarSesionActiva]
    public class EstudianteController : Controller
    {
        
        public ActionResult ListaEstudiantes()
        {
            List<Estudiante> lista = LogEstudiante.Instancia.ListarEstudiante();
            return View(lista);
        }
        public ActionResult CerrarSesion()
        {
            Session["usuario"] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}