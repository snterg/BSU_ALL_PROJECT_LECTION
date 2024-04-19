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
    /// Логика взаимодействия для Resources.xaml
    /// </summary>
    public partial class Resources : Window
    {
        public Resources()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            // определение объекта-ресурса
            LinearGradientBrush gradientBrush = new LinearGradientBrush();
            gradientBrush.GradientStops.Add(new GradientStop(Colors.LightGray, 0));
            gradientBrush.GradientStops.Add(new GradientStop(Colors.White, 1));

            // добавление ресурса в словарь ресурсов окна
            this.Resources.Add("buttonGradientBrush", gradientBrush);

            // установка ресурса у кнопки
            button1.Background = (Brush)this.TryFindResource("buttonGradientBrush");
            // или так
            button1.Foreground = (Brush)this.Resources["buttonGradientBrush"];

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //this.Resources["buttonBrush"] = new SolidColorBrush(Colors.LimeGreen);

            SolidColorBrush buttonBrush = (SolidColorBrush)this.TryFindResource("buttonBrush");
            buttonBrush.Color = Colors.LimeGreen;
            

        }
    }
}
