using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsSelection.AppData
{
    internal class HyperLinkHelper
    {
        public static void Navigate(System.Windows.Navigation.RequestNavigateEventArgs args)
        {
            Process.Start(new ProcessStartInfo(args.Uri.AbsoluteUri));
            args.Handled = true;
        }
    }
}
