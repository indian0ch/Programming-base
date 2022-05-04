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
    /// Логика взаимодействия для GetInformation.xaml
    /// </summary>
    public partial class GetInformation : Window
    {

        SqlConnection sqlConn = new SqlConnection(@"Data Source=EXTAZ;Initial Catalog=Lab3Test;Integrated Security=True");
        SqlCommand Com;
        SqlDataAdapter Data;
        DataTable dT = new DataTable();
        public GetInformation()
        {
            InitializeComponent();
        }

        private void ClientsBtn_Click(object sender, RoutedEventArgs e)
        {
            AboutClientInform ww;
            ww=new AboutClientInform();
            Hide();
            ww.Show();
        }

        private void WorkersBtn_Click(object sender, RoutedEventArgs e)
        {
            AboutWhoCleanRoom ww;
            ww= new AboutWhoCleanRoom();
            Hide();
            ww.Show();
        }
     
        private void FreeRoomBtn_Click(object sender, RoutedEventArgs e)
        {
            sqlConn.Open();
            long items = 0;
            if (sqlConn.State==System.Data.ConnectionState.Open)
            {
                Data=new SqlDataAdapter("SELECT * FROM Rooms",sqlConn);
                dT=new DataTable();
                Data.Fill(dT);
                for(int i=0;i<dT.Rows.Count;i++)
                {
                    if (dT.Rows[i][4].ToString() == "False")
                    {
                        items++;
                    }
                }
                if (items > 0)
                {
                    MessageBox.Show($"Кількість вільних номерів у готелі на поточний момент:{items}! ");
                }
                else if(items == 0)
                {
                    MessageBox.Show("У готелі немає вільних місць!");
                }
            }
          sqlConn.Close();
        }

        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ww;
            ww=new MainWindow();
            Hide();
            ww.Show();
        }
    }
}
