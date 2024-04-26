using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        Button btncode;
        int i = 0;
        int count_explanded=0, count_collapsed=0;
        public Controls_Base()
        {
            InitializeComponent();
            hide.Visibility = Visibility.Visible;
            btn.Content = 22.0 / 7;
            btncode = new Button { Content = "From C#" };
            btncode.Background = new LinearGradientBrush(Colors.Red, Colors.Green, new Point(0, 0), new Point(1, 1));
            btn_1.Content = btncode;

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            button1.Content = "Привет!";
        }

        private void btn_1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello from outer btn");
            btncode.Background = new SolidColorBrush(Colors.Gold);
        }

        private void brnimage_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("HEllo in BSU");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Entered IsDefault");
            IsDefault.BorderBrush = new SolidColorBrush(Colors.Red);
            IsDefault.Background = new SolidColorBrush(Colors.DarkRed);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Entered IsCancel");
            IsCancel.Foreground = new SolidColorBrush(Colors.Green);
        }

        private void Repeatbtn(object sender, RoutedEventArgs e)
        {
            if (i == 225)
                i = 0;
            repeatl.Content = "Кол-во: " + Convert.ToString(i);
            Color color = new Color();
            color.R = Convert.ToByte(255 - i - 20);
            color.G = Convert.ToByte(255 - i - 5);
            color.B = Convert.ToByte(255 - i);
            color.A = 255;
            repeatl.Background = new SolidColorBrush(color);
            ++i;
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as ToggleButton;

            MessageBox.Show("Состояние кнопки: " + btn.IsChecked.ToString());
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as CheckBox;

            if (btn.IsChecked == true)
            {
                btn.Content = "Отмечено";
            }
            else if (btn.IsChecked == false)
            {
                btn.Content = "Неотмечено";
            }
            else
            {
                btn.Content = "Неопределено";
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Эксклюзив для флага 1");
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Эксклюзив для флага 2");
        }

        private void CheckBox_Indeterminate(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Эксклюзив для флага 3");
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            var content = sender as RadioButton;

            MessageBox.Show("Элемент относится к группе " + content.GroupName);
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var content = sender as RadioButton;
          
            if(content.IsChecked==true)
            {
                MessageBox.Show("Элемент " + content.Content + " отмечен!");
            }
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            var content = sender as RadioButton;

            if (content.IsChecked == true)
            {
                MessageBox.Show("Элемент " + content.Content + " из группы "+ content.GroupName + " отмечен!");
            }          
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            popup.IsOpen = true;

        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            popup.IsOpen = false;
        }

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            count_explanded++;
            var content = sender as Expander;
            System.Windows.Controls.StackPanel stack = (System.Windows.Controls.StackPanel)content.Content;
            stack.Children.Add(new CheckBox() { Content = "Explanded " + Convert.ToString(count_explanded) });
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            scroll.LineDown();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            scroll.LineUp();
        }

        private void Expander_Collapsed(object sender, RoutedEventArgs e)
        {
            count_collapsed++;
            MessageBox.Show("Collapsed:" + Convert.ToString(count_collapsed));
            
        }
    }
}
