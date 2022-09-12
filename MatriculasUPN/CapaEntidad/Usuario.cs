using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MatriculasUPN.CapaEntidad
{
    public class Usuario : Persona
    {
        public int id;
        public string email { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Porfavor ingrese el Username"), MaxLength(30)]
        public string username { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Porfavor ingrese la Contraseña"), MaxLength(30)]
        public string password { get; set; }
        public int attemps { get; set; }

        public Usuario(string email, string username, string password, int attemps)
        {
            this.email = email;
            this.username = username;
            this.password = password;
            this.attemps = attemps;
        }

        public Usuario()
        {
        }
    }
}