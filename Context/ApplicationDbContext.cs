using Microsoft.EntityFrameworkCore;
using ProyectoFinal_23am.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_23am.Context
{
    public class ApplicationDbContext : DbContext //se pasa a publico y hereda de DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySQL("server=localhost; database= ProyectoDb23am; user=root; password='';");

        }
        //para mapear las tablas
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }

        //despues de hacer estas lineas se introduce en la consola de nugget
        //add-migration Nombredeejemplo
        //update-database

    }
}
