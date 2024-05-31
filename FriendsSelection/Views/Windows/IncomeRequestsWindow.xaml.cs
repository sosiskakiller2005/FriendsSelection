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
    /// Логика взаимодействия для IncomeRequestsWindow.xaml
    /// </summary>
    public partial class IncomeRequestsWindow : Window
    {
        private TeammateSearchDbEntities _context = App.GetContext();
        public IncomeRequestsWindow()
        {
            InitializeComponent();
            RequestsLV.ItemsSource = _context.Requests.Where(r => r.RecieverUserId == AuthorisationHelper.selectedUser.Id).ToList();
        }

        private void RequestsLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserWindow userWindow = new UserWindow((RequestsLV.SelectedItem as Requests).User);
            userWindow.ShowDialog();
            if (userWindow.DialogResult == true)
            {
                RequestsLV.ItemsSource = _context.Requests.Where(r => r.RecieverUserId == AuthorisationHelper.selectedUser.Id).ToList();
                DialogResult = true;
            }
        }
    }
}
