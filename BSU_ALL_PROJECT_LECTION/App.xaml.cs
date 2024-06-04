using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace BSU_ALL_PROJECT_LECTION
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
       public App()
        {
            //this.ShutdownMode = ShutdownMode.OnExplicitShutdown;
        }

        private void Application_NavigationFailed(object sender, System.Windows.Navigation.NavigationFailedEventArgs e)
        {
            if (e.Exception is System.Net.WebException)
            {
                MessageBox.Show("Сайт " + e.Uri.ToString() + " не доступен :(");
                // Нейтрализовать ошибку, чтобы приложение продолжило свою работу
                e.Handled = true;
            }
        }
    }
}
