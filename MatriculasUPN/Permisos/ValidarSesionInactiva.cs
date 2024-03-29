﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MatriculasUPN.Permisos
{
    public class ValidarSesionInactiva : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["usuario"] != null)
            {
                filterContext.Result = new RedirectResult("~/Estudiante/ListaEstudiantes");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}