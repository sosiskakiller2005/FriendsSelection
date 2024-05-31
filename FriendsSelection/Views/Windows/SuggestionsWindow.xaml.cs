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
    /// Логика взаимодействия для SuggestionsWindow.xaml
    /// </summary>
    public partial class SuggestionsWindow : Window
    {
        private TeammateSearchDbEntities _context = App.GetContext();
        public SuggestionsWindow(Game selectedGame, int ageRating, int selectedGenderId)
        {
            InitializeComponent();
            int requestedYear = DateTime.Now.Year - ageRating;
            //DateTime requestedDate = new DateTime(requestedYear, DateTime.Now.Month, DateTime.Now.Day);
            SuggestionsLV.ItemsSource = _context.UserGames.Where(ug => ug.GamesId == selectedGame.Id && ug.User.DateOfBirth.Year < requestedYear && ug.User.GenderId == selectedGenderId).ToList();
        }

        private void SuggestionsLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            User selectedUser = (SuggestionsLV.SelectedItem as UserGames).User;
            UserWindow userWindow = new UserWindow(selectedUser);
            userWindow.ShowDialog();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
