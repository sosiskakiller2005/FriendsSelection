using FriendsSelection.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FriendsSelection
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static TeammateSearchDbEntities _context;
        public static TeammateSearchDbEntities GetContext()
        {
            if (_context == null)
            {
                _context = new TeammateSearchDbEntities();
            }
            return _context;
        }
    }
}
