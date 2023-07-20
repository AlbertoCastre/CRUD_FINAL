using Microsoft.EntityFrameworkCore;
using ProyectoFinal_23am.Context;
using ProyectoFinal_23am.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ProyectoFinal_23am.Services
{
    public class UsuarioServices
    {
        //en Services va el CRUD y los metodos
        public void AddUser(Usuario request)//recibe el objeto usuario
        {//todos deben llevar try catch
            try
            {
                if (request != null)//validamos que no llegue en nulo 
                {
                    //si llega con datos se agrega a la base de datos
                    using (var _context = new ApplicationDbContext())
                    {//abrimos la conexion

                        Usuario res = new Usuario();//el objeto que va a recibir
                        res.Nombre = request.Nombre;
                        res.UserName = request.UserName;
                        res.Password = request.Password;
                        res.FkRol = request.FkRol;
                        
                        _context.Usuarios.Add(res);//guarda en la base de datos el nuevo objeto
                        _context.SaveChanges();//guardamos en la base

                    }//cerramos la conexion
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error :( "+ex.Message);
            }
        }
        public void DeleteUsuarios(int Id)
        {            
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Usuario res = _context.Usuarios.Find(Id);
                    if (res != null)
                    {
                        _context.Usuarios.Remove(res);//si existe esa PkUsuarios en la base de datos se elimina
                        _context.SaveChanges();//Guardamos datos
                    }
                    else
                    {
                        MessageBox.Show("No existe ese registro");
                    }            
                }

            }
            catch (Exception ex)
            {

                throw new Exception("No hay ese registro" + ex.Message);
            }
        }
        public void UpdateUser(Usuario request)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Usuario update = _context.Usuarios.Find(request.PkUsuario);
                    update.Nombre = request.Nombre;
                    update.UserName = request.UserName;
                    update.Password = request.Password; 
                    update.FkRol = request.FkRol;
                    _context.Usuarios.Update(update);

                    //_context.Entry(update).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Sucedio un error " + ex.Message);
            }
        }
        public List<Usuario> GetUsuarios()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Usuario> usuarios = new List<Usuario>();
                    usuarios = _context.Usuarios.Include(x => x.Roles).ToList();
                    return usuarios;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error "+ex.Message);
            }

        }
        public  List<Rol> GetRoles()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Rol> roles = _context.Roles.ToList();
                    return roles;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error"+ex.Message);
            }
        }
        public Usuario Login(string UserName, string Password)//regresa usuario y recibe 
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    var usuario = _context.Usuarios.Include(y => y.Roles).FirstOrDefault(x => x.UserName == UserName && x.Password == Password);
                    //por defecto el primero que encuentre
                    return usuario;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
