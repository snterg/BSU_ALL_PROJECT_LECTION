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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BSU_ALL_PROJECT_LECTION
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
  
    public partial class MainWindow : Window

    {
        public MainWindow()
        {
            SplashScreen splash = new SplashScreen("LAYOUT.png");
            //splash.Show(false);
            // splash.Show(true, false);
            splash.Show(false, true);
            splash.Close(TimeSpan.FromSeconds(7));

            InitializeComponent();
            //Button nb = new Button();
            //nb.Content = "C# button";
            //nb.Click +=btn3_Click;
            //nb.Width = 100;
            //nb.Height = 100;
            //nb.VerticalAlignment = VerticalAlignment.Top;
            //grid.Children.Add(nb);
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            string text = tb.Text;	//Определив имена элементов в XAML, можем к ним обращаться в коде c#
            if (text != "")
            {
                MessageBox.Show(text);
            }

        }

        private void btn3_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Привет");
        }
    }
}
