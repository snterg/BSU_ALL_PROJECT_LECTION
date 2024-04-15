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

namespace BSU_ALL_PROJECT_LECTION
{
    /// <summary>
    /// Логика взаимодействия для Controls_Base.xaml
    /// </summary>
    /// 


    public partial class Controls_Base : Window
    {
        public Controls_Base()
        {
            InitializeComponent();
                   }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            button1.Content = "Привет!";
        }

    }
}
