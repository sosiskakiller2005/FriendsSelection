using FriendsSelection.AppData;
using FriendsSelection.Model;
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

namespace FriendsSelection.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorisationWindow.xaml
    /// </summary>
    public partial class AuthorisationWindow : Window
    {
        private TeammateSearchDbEntities _context = App.GetContext();
        public AuthorisationWindow()
        {
            InitializeComponent();
            if (Properties.Resources.UserLogin != String.Empty && Properties.Resources.UserPassword != String.Empty)
            {
                LoginTb.Text = Properties.Resources.UserLogin;
                PasswordTb.Password = Properties.Resources.UserPassword;
            }
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AuthorisationHelper.Authorise(LoginTb.Text, PasswordTb.Password) == true)
            {
                //if (RememberMeCB.IsChecked == true)
                //{
                //    try
                //    {
                //        Properties.Resources.UserLogin = LoginTb.Text;
                //        Properties.Resources.UserPassword = PasswordTb.Password;

                //    }
                //    catch (Exception exc)
                //    {

                //        MessageBoxHelper.Error(exc.Message);
                //    }
                //}
                //else
                //{
                //    Properties.Resources.UserLogin = String.Empty;
                //    Properties.Resources.UserPassword = String.Empty;
                //}
                MenuWindow menuWindow = new MenuWindow();
                menuWindow.Show();
                Close();
            } 
        }

        private void RegisterHL_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            Close();
        }
    }
}
