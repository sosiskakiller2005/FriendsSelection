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
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        private TeammateSearchDbEntities _context = App.GetContext();
        private User _selectedUser;
        public UserWindow(User selectedUser)
        {
            _selectedUser = selectedUser;
            InitializeComponent();
            UserGamesLv.ItemsSource = selectedUser.UserGames.ToList();
            UserGrid.DataContext = selectedUser;
            if (_context.Friend.Any(f => f.UserId == AuthorisationHelper.selectedUser.Id && f.FriendUserId == selectedUser.Id) == true)
            {
                AddFriendBtn.Visibility = Visibility.Collapsed;
                DeleteFriendBtn.Visibility = Visibility.Visible;
            }
            else
            {
                AddFriendBtn.Visibility = Visibility.Visible;
                DeleteFriendBtn.Visibility = Visibility.Collapsed;
            }
        }

        private void UserGamesLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GameWindow gameWindow = new GameWindow((UserGamesLv.SelectedItem as UserGames).Game as Game);
            gameWindow.ShowDialog();
        }

        private void AddFriend_Click(object sender, RoutedEventArgs e)
        {
            if (_context.Requests.Any(r => r.RequestUserId == _selectedUser.Id) == true)
            {
                Friend newFriend = new Friend()
                {
                    UserId = AuthorisationHelper.selectedUser.Id,
                    FriendUserId = _selectedUser.Id,
                };
                _context.Requests.Remove(_context.Requests.First(r => r.RequestUserId == _selectedUser.Id && r.RecieverUserId == AuthorisationHelper.selectedUser.Id));
                _context.Friend.Add(newFriend);
                _context.SaveChanges();
                MessageBoxHelper.Information("Друг добавлен");
                DialogResult = true;
                AddFriendBtn.Visibility = Visibility.Collapsed;
                DeleteFriendBtn.Visibility = Visibility.Visible;
            }
            else
            {
                Requests newRequest = new Requests() { 
                    RequestUserId = AuthorisationHelper.selectedUser.Id,
                    RecieverUserId = _selectedUser.Id
                };
                _context.Requests.Add(newRequest);
                _context.SaveChanges();
                MessageBoxHelper.Information("Заявка отправлена");
            }
        }

        private void DeleteFriend_Click(object sender, RoutedEventArgs e)
        {
            _context.Friend.Remove(_context.Friend.First(f => f.UserId == AuthorisationHelper.selectedUser.Id && f.FriendUserId == _selectedUser.Id));
            _context.SaveChanges();
            DeleteFriendBtn.Visibility = Visibility.Collapsed;
            AddFriendBtn.Visibility = Visibility.Visible;
            MessageBoxHelper.Information("Друг удален");
        }
    }
}
