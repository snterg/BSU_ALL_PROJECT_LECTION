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
    /// Логика взаимодействия для commands_el.xaml
    /// </summary>
    /// 
    public class WindowCommands
    {
        static WindowCommands()
        {
            InputGestureCollection inputs = new InputGestureCollection();
            inputs.Add(new KeyGesture(Key.R, ModifierKeys.Control, "Ctrl + R"));
            Exit = new RoutedCommand("Exit", typeof(commands_el), inputs);
            
        }
        public static RoutedCommand Exit { get; set; }
    }
    public partial class commands_el : Window
    {
        public commands_el()
        {
            InitializeComponent();
            helpButton_2.Command= ApplicationCommands.Help;

            // создаем привязку команды
            CommandBinding commandBinding = new CommandBinding();
            // устанавливаем команду
            commandBinding.Command = ApplicationCommands.Help;
            // устанавливаем метод, который будет выполняться при вызове команды
            commandBinding.Executed += CommandBinding_Executed;
            commandBinding.CanExecute += CommandBinding_CanExecuted;
            // добавляем привязку к коллекции привязок элемента Button
            helpButton.CommandBindings.Add(commandBinding);

        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            save();
        }

        private void CommandBinding_CanExecuted(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute =DateTime.Now.Day % 2 == 0;
                
        }

        void save()
        {
            MessageBox.Show("Справка по приложению");
        }

        private void WindowBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Вызов справки");
        }

        private void Exit_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter("log.txt", true))
            {
                writer.WriteLine("Выход из приложения: " + DateTime.Now.ToShortDateString() + " " +
                DateTime.Now.ToLongTimeString());
                writer.Flush();
            }

            this.Close();
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = txtBox.Text.Count() != 0;
        }

        private void CommandBinding_Executed_1(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Команда выполняется");
        }
    }
}
