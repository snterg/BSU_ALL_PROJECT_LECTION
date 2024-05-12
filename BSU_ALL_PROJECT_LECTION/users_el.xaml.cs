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
    /// Логика взаимодействия для users_el.xaml
    /// </summary>
    public partial class users_el : Window
    {
        public users_el()
        {
            InitializeComponent();
        }

        private void clr_ColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {
            System.Windows.MessageBox.Show("Цвет изменился на " + e.NewValue);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var c=clr_slider.Color;
            var r = clr_slider.Red;
            var g = clr_slider.Green;
            var b = clr_slider.Blue;
        }
    }
}
