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
using System.Data;
using System.Data.SqlClient;

namespace HotelProgramTest
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Window
    {
        SqlConnection sqlConn = new SqlConnection(@"Data Source=EXTAZ;Initial Catalog=Lab3Test;Integrated Security=True");
        SqlCommand Com;
        SqlDataAdapter Data, Data1, Data2;
        DataTable dT = new DataTable();

        public AdminPage()
        {
            InitializeComponent();
            this.WindowStartupLocation=System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void AdminLoginTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            AdminLoginTextBox.Text = null;
        }

        private void AdminPasswordTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            AdminPasswordTextBox.Text = null;
        }

        private void AutBtn_Click(object sender, RoutedEventArgs e)
        {
            sqlConn.Open();
            var passAdm=AdminPasswordTextBox.Text;
            var logAdm=AdminLoginTextBox.Text;
            if(sqlConn.State==System.Data.ConnectionState.Open)
            {
                String strQ = "SELECT * FROM Admins WHERE login='"+logAdm+"'";
                Data = new SqlDataAdapter(strQ, sqlConn);
                dT=new DataTable();
                Data.Fill(dT);
                if(dT.Rows[0][1].ToString() == passAdm)
                {
                    AdminPag ww;
                    ww = new AdminPag();
                    Hide();
                    ww.Show();
                }
                else
                {
                    MessageBox.Show("Ви ввели невірні дані!");
                }
            }
            sqlConn.Close();
           

        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ww;
            ww = new MainWindow();
            Hide();
            ww.Show();
                
        }
    }
}
