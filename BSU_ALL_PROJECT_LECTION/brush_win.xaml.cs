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
    /// Логика взаимодействия для brush_win.xaml
    /// </summary>
    public partial class brush_win : Window
    {
        public brush_win()
        {
            InitializeComponent();
            linegr.Background = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            solidbtn.Background = new SolidColorBrush(Colors.Blue);
            //или так - это цвет #cfffff
            solidbtn.Foreground = new SolidColorBrush(Color.FromRgb(207, 255, 255));

        }
    }
}
