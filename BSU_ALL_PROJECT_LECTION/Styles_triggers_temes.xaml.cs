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
    /// Логика взаимодействия для Styles_triggers_temes.xaml
    /// </summary>
    public partial class Styles_triggers_temes : Window
    {
        public Styles_triggers_temes()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            MessageBox.Show(clickedButton.Content.ToString());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            clickedButton.Content = "Ты нажал на кнопку!";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            clickedButton.Background = new SolidColorBrush(Colors.DarkMagenta);
        }

        private void button13_Click(object sender, RoutedEventArgs e)
        {
            Style buttonStyle = new Style();
            buttonStyle.Setters.Add(new Setter { Property = Control.FontFamilyProperty, Value = new FontFamily("Verdana") });
            buttonStyle.Setters.Add(new Setter { Property = Control.MarginProperty, Value = new Thickness(10) });
            buttonStyle.Setters.Add(new Setter { Property = Control.BackgroundProperty, Value = new SolidColorBrush(Colors.Black) });
            buttonStyle.Setters.Add(new Setter { Property = Control.ForegroundProperty, Value = new SolidColorBrush(Colors.White) });
            buttonStyle.Setters.Add(new EventSetter { Event = Button.ClickEvent, Handler = new RoutedEventHandler(button13_1Click) });
            button13.Style = buttonStyle;

        }

        private void button13_1Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Клик, Клик!");

        }

        private void themebox_Initialized(object sender, EventArgs e)
        {
            List<string> styles = new List<string> { "light", "dark" };
            themebox.ItemsSource = styles;
        }

        private void themebox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string style = themebox.SelectedItem as string;
            // определяем путь к файлу ресурсов
            var uri = new Uri(style + ".xaml", UriKind.Relative);
            // загружаем словарь ресурсов
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            // очищаем коллекцию ресурсов приложения
            Application.Current.Resources.Clear();
            // добавляем загруженный словарь ресурсов
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
    }
}
