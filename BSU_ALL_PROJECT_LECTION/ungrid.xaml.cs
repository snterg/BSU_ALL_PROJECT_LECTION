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
    /// Логика взаимодействия для ungrid.xaml
    /// </summary>
    public partial class ungrid : Window
    {
        public ungrid()
        {
            InitializeComponent();
            Label x = new Label();
            x.Content = "Hello";
            ugrid.Children.Add(x);
        }
    }
}
