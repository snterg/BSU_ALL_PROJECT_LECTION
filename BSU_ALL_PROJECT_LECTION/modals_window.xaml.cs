using Microsoft.Win32;
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
    /// Логика взаимодействия для modals_window.xaml
    /// </summary>
    public partial class modals_window : Window
    {
        public modals_window()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Простое модальное окно");
            MessageBox.Show("Простое модальное окно", "Заголовок модального окна");
            var res = MessageBox.Show("Простое модальное окно", "Заголовок модального окна", MessageBoxButton.YesNoCancel);
          
            switch (res)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show(MessageBoxResult.Yes.ToString());
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show(MessageBoxResult.No.ToString());
                    break;
                case MessageBoxResult.Cancel:
                    MessageBox.Show(MessageBoxResult.Cancel.ToString());
                    break;
                default:
                    MessageBox.Show(MessageBoxResult.None.ToString());
                    break;
            }

            var result = MessageBox.Show("Простое модальное окно", "Заголовок модального окна", MessageBoxButton.YesNoCancel, MessageBoxImage.Information);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog myDialog = new OpenFileDialog();
            myDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF" + "|All files (*.*)|*.*";
            myDialog.CheckFileExists = true;
            myDialog.Multiselect = true;
            if (myDialog.ShowDialog() == true)
            {
                MessageBox.Show(myDialog.FileName);
            }
            else
            {
                MessageBox.Show("Ничего не выбрано");
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            stat.txt = input.Text;
            string txt_1 = input.Text;
            Page2 page = new Page2(txt_1);
            page.Show();
        }
    }
}
