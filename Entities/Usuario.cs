using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_23am.Entities
{
    public class Usuario//todas las tablas deben tener Pk
    {
        [Key]
        public int PkUsuario { get; set; }
        public string Nombre { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        [ForeignKey("Roles")]//ponemos el nombre de lo que creamos donde llamamos la tabla 
        public int? FkRol { get; set; }//? significa que puede estar vacio es decir no es obligatorio
        public Rol Roles { get; set; }//para llamar a la tabla roles
    }
}
