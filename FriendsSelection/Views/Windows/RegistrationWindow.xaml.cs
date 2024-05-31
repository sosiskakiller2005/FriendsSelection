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
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        static TeammateSearchDbEntities _context = App.GetContext();
        public RegistrationWindow()
        {
            InitializeComponent();
            GenderCmb.ItemsSource = _context.Gender.ToList();
            GenderCmb.DisplayMemberPath = "Name";
        }
        private void registerBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User newUser = new User()
                {
                    Lastname = LastnameTb.Text,
                    Name = NameTb.Text,
                    Surname = SurnameTb.Text,
                    Gender = GenderCmb.SelectedItem as Gender,
                    Email = eEmailTb.Text,
                    DateOfBirth = (DateTime)DateOfBirthPicker.SelectedDate,
                    Login = LoginTb.Text,
                    Password = PasswordTb.Password
                };
                _context.User.Add(newUser);
                _context.SaveChanges();
                MessageBoxHelper.Information("Новый пользователь зарегистрирован.");
                AuthorisationWindow authorisation = new AuthorisationWindow();
                authorisation.Show();
                Close();
            }
            catch (InvalidOperationException)
            {

                MessageBoxHelper.Error("Не все поля для ввода были заполнены");
            }

        }

        private void AuthorisationHL_Click(object sender, RoutedEventArgs e)
        {
            AuthorisationWindow authorisationWindow = new AuthorisationWindow();
            authorisationWindow.Show();
            Close();
        }
    }
}
