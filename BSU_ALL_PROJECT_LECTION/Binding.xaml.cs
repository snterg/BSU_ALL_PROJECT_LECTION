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
    /// Логика взаимодействия для Binding.xaml
    /// </summary>
    /// 
    public partial class Binding : Page
    {

        public Users user;
        public Binding()
        {
            InitializeComponent();
            System.Windows.Data.Binding binding = new System.Windows.Data.Binding();
            binding.Source = null;
            binding.TargetNullValue="нет объекта";
            NULLVAL.SetBinding(TextBlock.TextProperty, binding);

        }

        private void lblSampleText_MouseDown(object sender, MouseButtonEventArgs e)
        {
            lblSampleText.FontSize = 4;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Получить привязку, примененную к текстовому полю.
            BindingExpression binding = textBox2.GetBindingExpression(TextBox.TextProperty);
            // Обновить связанный источник (TextBlock).
            binding.UpdateSource();

        }

        private void Textbox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (Textbox1.Text.Length > 6 && Textbox1.Text.Contains('#'))
                {
                    MessageBox.Show(innergrid.Background.ToString());
                    MessageBox.Show(Textbox1.Background.ToString());
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
            
        }
    }
}
