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
    /// Логика взаимодействия для FindSuggestWindow.xaml
    /// </summary>
    public partial class FindSuggestWindow : Window
    {
        private TeammateSearchDbEntities _context = App.GetContext();
        public FindSuggestWindow()
        {
            InitializeComponent();

            List<string> ageRating = new List<string>();
            ageRating.Insert(0, "от 14 лет");
            ageRating.Insert(1, "от 18 лет");
            GameCmb.ItemsSource = _context.Game.ToList();
            GameCmb.DisplayMemberPath = "Name";
            AgeRatingCmb.ItemsSource = ageRating;
            GenderCmb.ItemsSource = _context.Gender.ToList();
            GenderCmb.DisplayMemberPath = "Name";
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow = new MenuWindow();
            menuWindow.Show();
            Close();
        }

        private void FindBtn_Click(object sender, RoutedEventArgs e)
        {
            switch (AgeRatingCmb.SelectedIndex)
            {
                case 0:
                    SuggestionsWindow suggestionsWindow = new SuggestionsWindow(GameCmb.SelectedItem as Game, 14, GenderCmb.SelectedIndex + 1);
                    suggestionsWindow.ShowDialog();
                    break;
                case 1:
                    SuggestionsWindow suggestionsWindow2 = new SuggestionsWindow(GameCmb.SelectedItem as Game, 18, GenderCmb.SelectedIndex + 1);
                    suggestionsWindow2.ShowDialog();
                    break;
            }
        }
    }
}
