using MatriculasUPN.CapaAccesoDatos;
using MatriculasUPN.CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatriculasUPN.CapaLogica
{
    public class LogUsuario
    {
        #region singleton
        private static readonly LogUsuario instancia = new LogUsuario();
        public static LogUsuario Instancia
        {
            get
            {
                return instancia;
            }
        }
        #endregion singleton

        #region methods
        public Usuario VerificarAcceso(String username, String password)
        {
            if (username == null) username = "";
            if (password == null) password = "";

            Usuario user = DatUsuario.Instancia.VerificarAcceso(username, password);

            if (user != null)
            {
                DatUsuario.Instancia.ReiniciarIntentos(username);
            }

            return user;
        }
        public int VerificarIntentos(String username)
        {
            if (username == null) username = "";

            return DatUsuario.Instancia.VerificarIntentos(username);
        }

        public void AumentarIntentos(String username)
        {
            if (username == null) username = "";

            DatUsuario.Instancia.AumentarIntentos(username);
        }
        #endregion metodos
    }
}
