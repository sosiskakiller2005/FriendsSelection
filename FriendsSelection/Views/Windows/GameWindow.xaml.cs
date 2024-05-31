using FriendsSelection.AppData;
using FriendsSelection.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public GameWindow(Game selectedGame)
        {
            InitializeComponent();
            GameGrid.DataContext = selectedGame;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SteamHL_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            HyperLinkHelper.Navigate(e);
        }
    }
}
