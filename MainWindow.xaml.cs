using ProyectoFinal_23am.Services;
using ProyectoFinal_23am.Vistas;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoFinal_23am
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        UsuarioServices services = new UsuarioServices();
        private void btnLogin_Click(object sender, RoutedEventArgs e)//boton login
        {
            string user = txtUserName.Text;
            string password = txtPassword.Text;

            var response = services.Login(user, password);//le agrego el usuario y la contraseña

            if (response != null)
            {
                if (response.Roles.Nombre == "Programador")
                {
                    Sistema sistema = new Sistema();//se instancea para poder usarlo
                    sistema.Show();//para abrir
                    Close();//para cerrar la primera pestaña
                }
                else
                {
                    SistemaCopia sistemaCopia = new SistemaCopia(); 
                    sistemaCopia.Show();
                    Close();
                }
            }

            
        }
    }
}
