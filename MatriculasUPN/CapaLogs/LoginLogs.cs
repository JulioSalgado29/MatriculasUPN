using MatriculasUPN.CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatriculasUPN.CapaLogs
{
    public class LoginLogs
    {
        public Usuario usuario { get; set; }
        public DateTime fechaIngreso { get; set; }

        public LoginLogs(Usuario usuario)
        {
            this.usuario = usuario;
        }
        public LoginLogs()
        {
        }
    }
}