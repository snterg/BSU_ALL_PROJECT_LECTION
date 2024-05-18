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
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace BSU_ALL_PROJECT_LECTION
{
    /// <summary>
    /// Логика взаимодействия для DataBase_w.xaml
    /// </summary>
    public partial class DataBase_w : Window
    {
        string connectionString;
        SqlDataAdapter adapter;
        DataTable phonesTable;

        public DataBase_w()
        {
            InitializeComponent();
            // получаем строку подключения из app.config
         
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT * FROM Phones";
            phonesTable = new DataTable();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);
                // установка команды на добавление для вызова хранимой процедуры
                adapter.InsertCommand = new SqlCommand("sp_InsertPhone", connection);
                //adapter.InsertCommand = new SqlCommand(sql, connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@title", SqlDbType.NChar, 10, "Title"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@company", SqlDbType.NChar, 10, "Company"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@price", SqlDbType.Int, 0, "Price"));
                SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
                parameter.Direction = ParameterDirection.Output;
                connection.Open();
                adapter.Fill(phonesTable);
                phonesGrid.ItemsSource = phonesTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

        }

        private void UpdateDB()
        {
            SqlCommandBuilder comandbuilder = new SqlCommandBuilder(adapter);
            adapter.Update(phonesTable);
        }
        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateDB();
        }
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (phonesGrid.SelectedItems != null)
            {
                while(phonesGrid.SelectedItems.Count>0)
                { 
                    DataRowView datarowView = phonesGrid.SelectedItems[0] as DataRowView;
                    if (datarowView != null)
                    {
                        DataRow dataRow = (DataRow)datarowView.Row;
                        dataRow.Delete();
                    }
                }
            }
            UpdateDB();
        }



    }
}
