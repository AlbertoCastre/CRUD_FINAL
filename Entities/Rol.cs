using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_23am.Entities
{
    public class Rol //se pasa publico
    {
        //indicamos que el siguinte es el primary key
        [Key] 
        public int PkRol { get; set; } //llave de rol 
        public string Nombre { get; set; }  //nombre de rol

    }
}
