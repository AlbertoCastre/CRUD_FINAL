using ProyectoFinal_23am.Entities;
using ProyectoFinal_23am.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProyectoFinal_23am.Vistas
{
    /// <summary>
    /// Lógica de interacción para Sistema.xaml
    /// </summary>
    public partial class Sistema : Window
    {
        public Sistema()
        {
            InitializeComponent();
            GetUsersTables();//para poder cargar la tabla usuarios
            GetRoles();
        }
        UsuarioServices services = new UsuarioServices();//para poder usar los metodos
        private bool ChangeFuncion = true;
        private void BtnAdd_Click(object sender, RoutedEventArgs e)//boton agregar de la pagina sistema
        {
            if(txtPkUser.Text == "")//si la Pk esta vacia se agrega usuario
            {
                Usuario usuario = new Usuario();//creamos un objeto de la clase usuarios con las caracteristicas
                usuario.Nombre = txtNombre.Text;//para traer los datos desde los txt
                usuario.UserName = txtUserName.Text;
                usuario.Password = txtPassword.Text;//pasamos los datos del txt al objeto
                usuario.FkRol = int.Parse(SelectRol.SelectedValue.ToString());
                //F9 para depurar
                services.AddUser(usuario);//usamos los metodos de la otra clase
                txtNombre.Clear();
                txtPassword.Clear();
                txtUserName.Clear();
                UserTable.ItemsSource = services.GetUsuarios();
                //Usamos el metodo para que se vayan actualizando en tiempo real
            }
            else
            {
                //editar
                int id = int.Parse(txtPkUser.Text);//guardamos el valor de la Pk del usuario seleccionado
                Usuario usuario = new Usuario();
                usuario.PkUsuario = id;
                usuario.Nombre = txtNombre.Text;//traemos los datos actulizados
                usuario.UserName = txtUserName.Text;
                usuario.Password = txtPassword.Text;
                usuario.FkRol = int.Parse(SelectRol.SelectedValue.ToString());
                services.UpdateUser(usuario);//usamos el metodo UpdateUser
                UserTable.ItemsSource = services.GetUsuarios();//actulizamos la tabla localmente
                MessageBox.Show("Se actulizaron los datos");
                txtNombre.Clear();
                txtPassword.Clear();
                txtUserName.Clear();
                txtPkUser.Clear();                
            }
        }
            
        public void EditItem(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario();
            
            usuario = (sender as FrameworkElement).DataContext as Usuario;//para mapear de acuerdo 

            txtPkUser.Text = usuario.PkUsuario.ToString();
            txtNombre.Text = usuario.Nombre.ToString();
            txtUserName.Text = usuario.UserName.ToString();
            txtPassword.Text = usuario.Password.ToString();
            int Id = int.Parse(txtPkUser.Text);
        }
        public void DeleteItem(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario();
            int Id = int.Parse(txtPkUser.Text);//comprobamos que exista un valor de PkUser para borrar
            if(string.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show("No se puede borrar esta vacio");
            }
            else
            {
                services.DeleteUsuarios(Id);
                MessageBox.Show("Se borraron los datos");
                txtNombre.Clear();
                txtPassword.Clear();
                txtUserName.Clear();
                txtPkUser.Clear();
                UserTable.ItemsSource = services.GetUsuarios();//refrescamos la tabla
            }

        }
        public void GetUsersTables()
        {
            UserTable.ItemsSource = services.GetUsuarios();//para poder poner los usuarios
        }

        public void GetRoles()
        {
            SelectRol.ItemsSource = services.GetRoles();//para traer los roles de la base de datos
            SelectRol.DisplayMemberPath = "Nombre";//aqui lo invocamos
            SelectRol.SelectedValuePath = "PkRol";
        }
    }
}
