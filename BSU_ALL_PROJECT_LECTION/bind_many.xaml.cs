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
    /// Логика взаимодействия для bind_many.xaml
    /// </summary>
    public partial class bind_many : Window
    {

        List<FontFamily> fontFamily;
        int i = 0;
        public bind_many()
        {
            InitializeComponent();
            fontFamily = Fonts.SystemFontFamilies.ToList();
        }

        private void ClrPcker_Background_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            color_items.Items.Add(e.NewValue.Value.ToString());
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {

            tgbtn.Content = fontFamily[i++];
        }

        private void canva_MouseEnter(object sender, MouseEventArgs e)
        {
            lcanva.Content = (e.GetPosition(this).X- e.GetPosition(this).Y) / 100;
           
        }
    }
}
