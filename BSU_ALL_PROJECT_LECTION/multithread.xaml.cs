using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using static Xceed.Wpf.Toolkit.Calculator;

namespace BSU_ALL_PROJECT_LECTION
{
    /// <summary>
    /// Логика взаимодействия для multithread.xaml
    /// </summary>
    /// 
    public class InputClass
    {
        public int To
        { get; set; }
        public int From
        { get; set; }

        public InputClass(int from, int to)
        {
            To = to;
            From = from;
        }
    }
    class Worker
    {
        public static int[] Find(int fromNumber, int toNumber)
        {
            return Find(fromNumber, toNumber, null);
        }
        public static int[] Find(int fromNumber, int toNumber, BackgroundWorker backgroundWorker)
        {
            int[] list = new int[toNumber - fromNumber];

            // Создать массив, содержащий все целые числа
            for (int i = 0; i < list.Length; i++)
            {
                list[i] = fromNumber;
                fromNumber += 1;
            }

            // Числа, кратные всем простым числам, меньшим или равным квадратному 
            // корню из максимального числа отмечаем цифрой 0 - это обычные числа.
            // Все остальные отмечаем 1 - это простые числа
            int maxDiv = (int)Math.Floor(Math.Sqrt(toNumber));

            int[] mark = new int[list.Length];


            for (int i = 0; i < list.Length; i++)
            {
                for (int j = 2; j <= maxDiv; j++)
                {

                    if ((list[i] != j) && (list[i] % j == 0))
                    {
                        mark[i] = 1;
                    }

                }

                int iteration = list.Length / 100;
                if ((i % iteration == 0) && (backgroundWorker != null))
                {
                    if (backgroundWorker.CancellationPending)
                    {
                        // Возврат без какой-либо дополнительной работы
                        return null;
                    }

                    if (backgroundWorker.WorkerReportsProgress)
                    {
                      
                        backgroundWorker.ReportProgress(i / iteration);
                      
                    }
                }

            }

            // Cоздать новый массив, который содержит только простые числа, и вернуть этот массив
            int primes = 0;
            for (int i = 0; i < mark.Length; i++)
            {
                if (mark[i] == 0) primes += 1;

            }

            int[] ret = new int[primes];
            int curs = 0;
            for (int i = 0; i < mark.Length; i++)
            {
                if (mark[i] == 0)
                {
                    ret[curs] = list[i];
                    curs += 1;
                }
            }

            if (backgroundWorker != null && backgroundWorker.WorkerReportsProgress)
            {
                backgroundWorker.ReportProgress(100);
            }

            return ret;
        }
    }

    public partial class multithread : Window
    {
        BackgroundWorker backgroundWorker;
        public multithread()
        {
            InitializeComponent();
            MessageBox.Show("MainProcess: " + System.Threading.Thread.CurrentThread.ManagedThreadId);
            btnstop.IsEnabled = false;
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
        }

        private void btnchange_Click(object sender, RoutedEventArgs e)
        {
            var s = sender as Button;
            Thread thread;
            if (s.Name.Contains("1"))
                thread = new Thread(UpdateTextWrong_1);
            else
                thread = new Thread(UpdateTextWrong);

            thread.Start();

        }

        private void UpdateTextWrong()
        {
            try
            {
                // Эмулирует некоторую работу посредством пятисекундной задержки
                MessageBox.Show("MainProcess: " + System.Threading.Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(TimeSpan.FromSeconds(5));
                txt.Text = "Вставить новый текст";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateTextWrong_1()
        {
            try
            {
                // Эмулирует некоторую работу посредством пятисекундной задержки
                Thread.Sleep(TimeSpan.FromSeconds(5));
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
                {
                   
                    MessageBox.Show("MainProcess: " + System.Threading.Thread.CurrentThread.ManagedThreadId);
                    txt_1.Text = DateTime.Now.ToString();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnstart_Click(object sender, RoutedEventArgs e)
        {
            btnstart.IsEnabled = false;
            btnstop.IsEnabled = true;
            changetext.Items.Clear();

            // Получить диапазон поиска
            int _from, _to;
            if (!Int32.TryParse(from.Text, out _from))
            {
                MessageBox.Show("Неверное значение начала диапазона");
                return;
            }
            if (!Int32.TryParse(to.Text, out _to))
            {
                MessageBox.Show("Неверное значение конца диапазона");
                return;
            }
            // Начать поиск простых чисел в другом потоке 
            InputClass input = new InputClass(_from, _to);
            backgroundWorker.RunWorkerAsync(input);
        }



        private void btnstop_Click(object sender, RoutedEventArgs e)
        {
            backgroundWorker.CancelAsync();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Получить входные значения 
            InputClass input = (InputClass)e.Argument;
            // Запустить поиск простых чисел и ждать. 
            // Это длительная часть работы, но она не подвешивает пользовательский интерфейс, поскольку выполняется в другом потоке 
            int[] primes = Worker.Find(input.From, input.To, backgroundWorker);

            if (backgroundWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            // Вернуть результат 
            e.Result = primes;

        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progress.Value = e.ProgressPercentage;
        }


        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Поиск отменен");
            }
            else
            if (e.Error != null)
            {
                // Ошибка была сгенерирована обработчиком события DoWork
                MessageBox.Show(e.Error.Message, "Произошла ошибка");
            }
            else
            {
                int[] primes = (int[])e.Result;
                foreach (int prime in primes)
                    changetext.Items.Add(prime);
            }
            btnstart.IsEnabled = true;
            btnstop.IsEnabled = false;
            progress.Value = 0;

        }

    }
}
