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
    /// Логика взаимодействия для MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
            //To do!!!!
            //if (AuthorisationHelper.isLoggedIn == true)
            //{
            //    FriendsSelection.Properties.Resources.UserLogin = AuthorisationHelper.selectedUser.Login;
            //}
        }

        private void TournamentScheduleBtn_Click(object sender, RoutedEventArgs e)
        {
            TournamentScheduleWindow tournamentScheduleWindow = new TournamentScheduleWindow();
            tournamentScheduleWindow.Show();
            Close();
        }

        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            ProfileWindow profileWindow = new ProfileWindow();
            profileWindow.Show();
            Close();
        }


        private void FAQBtn_Click(object sender, RoutedEventArgs e)
        {
            FAQWindow FAQWindow = new FAQWindow();
            FAQWindow.Show();
            Close();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void FindSuggest_Click(object sender, RoutedEventArgs e)
        {
            FindSuggestWindow findSuggestWindow = new FindSuggestWindow();
            findSuggestWindow.Show();
            Close();
        }
    }
}
