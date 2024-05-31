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
    /// Логика взаимодействия для TournamentScheduleWindow.xaml
    /// </summary>
    public partial class TournamentScheduleWindow : Window
    {
        TeammateSearchDbEntities _context = App.GetContext();
        public TournamentScheduleWindow()
        {
            InitializeComponent();
            TournamentDatesLV.ItemsSource = _context.Tournament.ToList();
            GameCmb.ItemsSource = _context.Game.ToList();
            GameCmb.DisplayMemberPath = "Name";
            GameCmb.SelectedIndex = 0;
        }

        private void GameCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TournamentDatesLV.ItemsSource = _context.Tournament.Where(t => t.GameId == GameCmb.SelectedIndex + 1).ToList();
        }

        private void TournamentDatesLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PrizeGrid.DataContext = TournamentDatesLV.SelectedItem;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow = new MenuWindow();
            menuWindow.Show();
            Close();
        }
    }
}
