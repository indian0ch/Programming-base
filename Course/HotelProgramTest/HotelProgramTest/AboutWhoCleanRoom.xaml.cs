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
    /// Логика взаимодействия для AboutWhoCleanRoom.xaml
    /// </summary>
    public partial class AboutWhoCleanRoom : Window
    {


        SqlConnection sqlConn = new SqlConnection(@"Data Source=EXTAZ;Initial Catalog=Lab3Test;Integrated Security=True");
        SqlCommand Com;
        SqlDataAdapter Data;
        DataTable dT = new DataTable();
        public AboutWhoCleanRoom()
        {
            InitializeComponent();
            SurnameClientCb.ItemsSource = GetItemsD();
            //SurnameClientCb.SelectedIndex = 0;
            DayWeekCb.ItemsSource = GetDay();
           // DayWeekCb.SelectedIndex = 0;
        }

        private void CheckWhoBtn_Click(object sender, RoutedEventArgs e)
        {
            
            String Surname= SurnameClientCb.SelectedItem.ToString();
            String DayWeek= DayWeekCb.SelectedItem.ToString();
            if (Surname == "" || DayWeek == "")
            {
                MessageBox.Show("You have to choose variants in both ComboBox!");
            }
            else
            {
                sqlConn.Open();
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    String strQ = "SELECT Surname,Name FROM Workers INNER JOIN DatesOfWork ON DatesOfWork.DayOfWeek = '" + DayWeek + "' AND DatesOfWork.NumberRoof IN(SELECT NumberRoof FROM Rooms INNER JOIN Persons ON Persons.Surname = '" + Surname + "' AND Persons.NumberRoom = Rooms.NumberRoom) AND Workers.IdWorkers = DatesOfWork.IdWorkers ;";
                    Data = new SqlDataAdapter(strQ, sqlConn);
                    dT = new DataTable();
                    Data.Fill(dT);
                    long buf = dT.Columns.Count;
                    long buf1 = dT.Rows.Count;
                    SurnameT.Text = dT.Rows[0][0].ToString();
                    NameR.Text = dT.Rows[0][1].ToString();
                }
                sqlConn.Close();
            }
        }

        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            GetInformation ww;
            ww=new GetInformation();
            Hide();
            ww.Show();
        }

        private void SurnameClientCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // sqlConn.Open();
           // Data
        }

        private void DayWeekCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private String[] GetItemsD()
        {
            String[] Items = { "" };
            sqlConn.Open();
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                Data = new SqlDataAdapter("Select * From Persons", sqlConn);
                dT = new DataTable();
                Data.Fill(dT);
                Items = new String[dT.Rows.Count];
                for (int i = 0; i < dT.Rows.Count; i++)
                {
                    Items[i] = dT.Rows[i][1].ToString();
                }
            }
            sqlConn.Close();
            return Items;
        }
        String[] Days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        private String[] GetDay()
        {
            String[] Days = { "Monday","Tuesday","Wednesday","Thursday","Friday","Saturday","Sunday" };

            return Days;
        }
    }
}
