using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Security.Policy;
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
    /// Логика взаимодействия для Controls_Base_two.xaml
    /// </summary>
    /// 

    public class Person
    {
        public int i { get; set; }
        public string Name_p { get; set; }
        public int age { get; set; }
    }
    public partial class Controls_Base_two : Window
    {

        

        List<string> phones = new List<string> { "iPhone 6S", "Lumia 950", "Nexus 5X", "LG G4", "Xiaomi MI5", "HTC A9" };


        public Controls_Base_two()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var s = sender as TextBox;
            MessageBox.Show("Вы ввели " + s.Text.Count().ToString() + " символов");
        }

        private void readonly_Checked(object sender, RoutedEventArgs e)
        {
            t1.IsReadOnly = t2.IsReadOnly = t3.IsReadOnly = t4.IsReadOnly = true;

        }

        private void readonly_Unchecked(object sender, RoutedEventArgs e)
        {
            t1.IsReadOnly = t2.IsReadOnly = t3.IsReadOnly = t4.IsReadOnly = false;
        }

        private void t4_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show(t4.SelectedText);
            t4.Focus();
        }

        private void PasswordBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show(ps.Password);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var items = LBox.Items.Count;

            MessageBox.Show("Кол-во элементов в списке:" + items.ToString());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string nitem = "Новый элемент списка";
            if (LBox.ItemsSource is null)
            {
                LBox.Items.Add(nitem);
            }
            else
            {
                phones.Add(nitem);
                LBox.ItemsSource = null;
                LBox.ItemsSource = phones;
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var s = LBox.SelectedItem;
            if (s is null)
            {
                MessageBox.Show("Элемент для удаления не выбран");
                return;
            }

            if (LBox.ItemsSource is null)
            {
                LBox.Items.Remove(s);
            }
            else
            {
                phones.RemoveAt(LBox.SelectedIndex);
                LBox.ItemsSource = null;
                LBox.ItemsSource = phones;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (LBox.ItemsSource is null)
            {
                LBox.Items.Clear();
            }
            else
            {
                LBox.ItemsSource = null;
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (LBox.ItemsSource is null && LBox.Items.Count != 0)
            {
                foreach (var item in phones)
                    LBox.Items.Add(item);
            }
            else
                LBox.ItemsSource = phones;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            LBox.ItemsSource = null;
            LBox.Items.Clear();
            LBox.ItemsSource = new List<Person>
            {
                new Person{i=1, age=27, Name_p="Ivan" },
              new Person{ i=2, age=34, Name_p="Alecia" },
             new Person{  i =3, age = 45, Name_p = "Jora" },
            };
            LBox.DisplayMemberPath = "Name";
        }

        private void phonesList_2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Person Raman = new Person { i = 4, age = 23, Name_p = "Raman" };
            //приведение ресурса phones к типу ArrayList
            ((ArrayList)phonesList_2.Resources["persons"]).Add(Raman);
           
            phonesList_2.ItemsSource = null;
            phonesList_2.ItemsSource = ((ArrayList)phonesList_2.Resources["persons"]);

        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            var slider = sender as Slider;
            var a = slider.Value;
            slider.SelectionEnd = e.NewValue;
            slider_l.Content = progress.Value = a;

        }

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = calendar1.SelectedDate;

            MessageBox.Show(selectedDate.Value.Date.ToShortDateString());
        }

    }
}
