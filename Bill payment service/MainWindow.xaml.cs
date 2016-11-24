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

namespace Bill_payment_service
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CRUD crud = new CRUD();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonRegistrationRegistration_Click(object sender, RoutedEventArgs e)
        {
            if (crud.Registration(textBoxRegistrationLogin.Text, passwordBoxRegistrationPassword.Password))
            {
                this.Close();
            }
        }

        private void buttonAuthorizationLogin_Click(object sender, RoutedEventArgs e)
        {
            if (crud.Login(textBoxAuthorizationLogin.Text, passwordBoxAuthorizationPassword.Password))
            {
                this.Close();
            }  
            
        }
    }
}
