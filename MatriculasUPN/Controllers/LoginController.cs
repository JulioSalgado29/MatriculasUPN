using MatriculasUPN.CapaEntidad;
using MatriculasUPN.CapaLogica;
using MatriculasUPN.CapaLogs;
using MatriculasUPN.Permisos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MatriculasUPN.Controllers
{
    [ValidarSesionInactiva]
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Usuario user)
        {
            int attemps = LogUsuario.Instancia.VerificarIntentos(user.username);

            if (attemps == -1)
            {
                ViewBag.Message = "Usuario no encontrado";
                return View();
            }
            else
            {
                if (attemps >= 3)
                {
                    ViewBag.Message = "El usuario esta  excedió la cantidad de intentos";
                    return View();
                }
                else
                {
                    Usuario userNew = LogUsuario.Instancia.VerificarAcceso(user.username, user.password);

                    if(userNew == null)
                    {
                        LogUsuario.Instancia.AumentarIntentos(user.username);
                        ViewBag.Message = "Contraseña Equivocada - Le quedan " + (2-attemps) + " intentos";
                        return View();
                    }
                    else
                    {
                        //REGISTRO DE LOGIN
                        DateTime dateTime = DateTime.Now;
                        LoginLogs loginLogs = new LoginLogs();
                        loginLogs.usuario = userNew;
                        loginLogs.fechaIngreso = dateTime;
                        LogLogs.Instancia.CrearRegistroLog(loginLogs);

                        Session["usuario"] = userNew;
                        Session["idUsuario"] = userNew.id;
                        Session["nombreUsuario"] = userNew.name;
                        return RedirectToAction("ListaEstudiantes", "Estudiante");
                    }
                }
            }
        }
    }
}
