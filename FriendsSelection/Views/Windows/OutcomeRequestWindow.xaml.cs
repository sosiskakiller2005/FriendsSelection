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
    /// Логика взаимодействия для OutcomeRequestWindow.xaml
    /// </summary>
    public partial class OutcomeRequestWindow : Window
    {
        private TeammateSearchDbEntities _context = App.GetContext();
        public OutcomeRequestWindow()
        {
            InitializeComponent();
            RequestsLV.ItemsSource = _context.Requests.Where(r => r.RequestUserId == AuthorisationHelper.selectedUser.Id).ToList();
        }

        private void RequestsLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Requests selectedRequests = RequestsLV.SelectedItem as Requests;
            if (MessageBoxHelper.Question("Удалить заявку?") == true)
            {
                _context.Requests.Remove(_context.Requests.First(r => r.RequestUserId == AuthorisationHelper.selectedUser.Id && r.RecieverUserId == selectedRequests.RecieverUserId));
                DialogResult = true;
            }
            RequestsLV.ItemsSource = _context.Requests.Where(r => r.RequestUserId == AuthorisationHelper.selectedUser.Id).ToList();
            _context.SaveChanges();
        }
    }
}
