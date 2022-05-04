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
    /// Логика взаимодействия для AboutClientInform.xaml
    /// </summary>
    public partial class AboutClientInform : Window
    {
        SqlConnection sqlConn = new SqlConnection(@"Data Source=EXTAZ;Initial Catalog=Lab3Test;Integrated Security=True");
        SqlCommand Com;
        SqlDataAdapter Data,Data1,Data2;
        DataTable dT = new DataTable();
        public AboutClientInform()
        {
            InitializeComponent();
            RoomsCb.ItemsSource = GetItemsR();
            RoomsCb.SelectedIndex = 0;
        }
        DataTable dT1=new DataTable();
        DataTable dT2 = new DataTable();
        private void RoomsCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NameT.Content = null;
            SurnameT.Content = null;
            CityT.Content = null;   
            SecNameT.Content = null;
            DateT.Content = null;
            String Text=RoomsCb.SelectedItem.ToString();    
            sqlConn.Open();
            Data=new SqlDataAdapter($"SELECT Status2 FROM Rooms WHERE NumberRoom={Text}",sqlConn);
            dT1=new DataTable();
            Data.Fill(dT1);
            if (dT1.Rows[0][0].ToString()==checking)
            {
                ChBox.IsChecked = false;
                Data = new SqlDataAdapter($"SELECT Surname,Name,SecName,City,DataZasel FROM Persons WHERE NumberRoom={Text}", sqlConn);
                dT = new DataTable();
                Data.Fill(dT);
                NameT.Content = $"{dT.Rows[0][1]}";
                SurnameT.Content = $"{dT.Rows[0][0]}";
                SecNameT.Content = $"{dT.Rows[0][2]}";
                CityT.Content = $"{dT.Rows[0][3]}";
                DateT.Content = $"{dT.Rows[0][4]}";
            }
            else
            {
                ChBox.IsChecked = true;
            }
            sqlConn.Close();
        }
        string checking = "True";
        string checkingf = "False";
        private void CheckCityBtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateDataTable();
        }
        static long count = 0;
        private void UpdateDataTable()
        {
            GetItemsC();
      
            String Text=CityTb.Text;
            
            for(int i = 0; i <ItemsC.Length;i++)
            {
                if(ItemsC[i].ToString()==Text)
                {
                    count++;
                }
            }
            
            if (count > 0)
            {
                sqlConn.Open();
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    String strQ = $"SELECT Surname[Прізвище], Name[Ім'я],SecName[По-батькові],DataZasel[Дата-заселення] FROM Persons WHERE Persons.City='"+Text+"'";
                    Data = new SqlDataAdapter(strQ, sqlConn);
                    dT = new DataTable();
                    Data.Fill(dT);
                    dataGrid.ItemsSource = dT.DefaultView;
                }

                sqlConn.Close();
            }
            else if (count ==0 )
            {
                MessageBox.Show("Клієнти з цього міста не живуть у нашому готелі!");
            }
            count = 0;
        }
        String[] ItemsC = { "" };
        private String[] GetItemsC()
        {
            
            sqlConn.Open();
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                Data = new SqlDataAdapter("Select * From Persons", sqlConn);
                dT = new DataTable();
                Data.Fill(dT);
                ItemsC = new String[dT.Rows.Count];
                for (int i = 0; i < dT.Rows.Count; i++)
                {
                    ItemsC[i] = dT.Rows[i][4].ToString();
                }
            }
            sqlConn.Close();
            return ItemsC;
        }

        private void CityTb_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            CityTb.Text = null;
        }

        private void CityTb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            GetInformation ww;
            ww=new GetInformation();
            Hide();
            ww.Show();
        }
        /*
        private void CheckRoomBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        */
        private String[] GetItemsR()
        {
            String[] Items = { "" };
            sqlConn.Open();
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                Data = new SqlDataAdapter("Select * From Rooms", sqlConn);
                dT = new DataTable();
                Data.Fill(dT);
                Items = new String[dT.Rows.Count];
                for (int i = 0; i < dT.Rows.Count; i++)
                {
                    Items[i] = dT.Rows[i][0].ToString();
                }
            }
            sqlConn.Close();
            return Items;
        }
    }
}
