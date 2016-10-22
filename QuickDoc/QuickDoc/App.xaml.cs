using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace QuickDoc
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //e.Args is the string[] of command line argruments
            MainWindow wnd = null;
            if (e.Args.Length >= 1)
            {
                wnd = new MainWindow(e.Args[0]);
                wnd.Show();
            }
        }
    }
}
