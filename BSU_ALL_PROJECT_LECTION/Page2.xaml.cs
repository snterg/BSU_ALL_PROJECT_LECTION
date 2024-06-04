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
using static BSU_ALL_PROJECT_LECTION.modals_window;

namespace BSU_ALL_PROJECT_LECTION
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Window
    {
        public Page2()
        {
            InitializeComponent();
            static_t.Text+= " " + stat.txt;
          //  System.Windows.Application.Current.Shutdown();
        }

        public Page2(string str):this()
        {
            construct_t.Text += " "+str;
        }

        public Page2(InputParams param) : this()
        {
            input_1.DataContext = param;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();

        }
    }
}
