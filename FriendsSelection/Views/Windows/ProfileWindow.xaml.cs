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
    /// Логика взаимодействия для ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        private TeammateSearchDbEntities _context = App.GetContext();
        public ProfileWindow()
        {
            InitializeComponent();
            UserGrid.DataContext = AuthorisationHelper.selectedUser;
            List<User> users = _context.User.ToList();
            int usersCount = users.Count;
            PlayersCountTbl.Text = $"Игроков в поиске: {usersCount}";
        }

        private void RequestsHL_Click(object sender, RoutedEventArgs e)
        {
            IncomeRequestsWindow incomeRequestsWindow = new IncomeRequestsWindow();
            incomeRequestsWindow.ShowDialog();
            if (incomeRequestsWindow.DialogResult == true)
            {
                UserGrid.DataContext = AuthorisationHelper.selectedUser;
            }
        }

        private void IncomeRequestsHL_Click(object sender, RoutedEventArgs e)
        {
            OutcomeRequestWindow outcomeRequestWindow = new OutcomeRequestWindow();
            outcomeRequestWindow.ShowDialog();
            if (outcomeRequestWindow.DialogResult == true)
            {
                UserGrid.DataContext = AuthorisationHelper.selectedUser;
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow = new MenuWindow();
            menuWindow.Show();
            Close();
        }

        private void FindSuggestHL_Click(object sender, RoutedEventArgs e)
        {
            FindSuggestWindow findSuggestWindow = new FindSuggestWindow();
            findSuggestWindow.Show();
            Close();
        }

        private void TournamentHL_Click(object sender, RoutedEventArgs e)
        {
            TournamentScheduleWindow tournament = new TournamentScheduleWindow();
            tournament.Show();
            Close();
        }
    }
}
