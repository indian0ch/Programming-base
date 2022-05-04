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
    /// Логика взаимодействия для ZvitClients.xaml
    /// </summary>
    public partial class ZvitClients : Window
    {
        SqlConnection sqlConn = new SqlConnection(@"Data Source=EXTAZ;Initial Catalog=Lab3Test;Integrated Security=True");
        SqlCommand Com, Com1;
        SqlDataAdapter Data, Data1, Data2;
        DataTable dT = new DataTable();

        private void CheckBtn_Click(object sender, RoutedEventArgs e)
        {
            String id=SurnameCb.SelectedItem.ToString();
            sqlConn.Open();
            var passw = PswTb.Text.ToString();
            if(sqlConn.State==System.Data.ConnectionState.Open)
            {
                String strQ = "SELECT * FROM Persons WHERE IdPerson='"+id+"';";
                Data=new SqlDataAdapter(strQ,sqlConn);
                dT=new DataTable();
                Data.Fill(dT);
                if(dT.Rows[0][6].ToString()==passw)
                {
                    MakeZvitBtn.IsEnabled = true;
                    MessageBox.Show("Ви успішно ввійшли!");
                }
                else
                {
                    MessageBox.Show("Ви ввели неправильний пароль!");
                }
            }

            sqlConn.Close();
        }

        private void PswTb_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            PswTb.Text = null;
        }

        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ww;
            ww=new MainWindow();
            Hide();
            ww.Show();
        }

        public ZvitClients()
        {
            InitializeComponent();
            SurnameCb.ItemsSource = GetItems();
            SurnameCb.SelectedIndex = 0;
            MakeZvitBtn.IsEnabled = false;
        }

        private void MakeZvitBtn_Click(object sender, RoutedEventArgs e)
        {
            String Surname=SurnameCb.SelectedItem.ToString();
            sqlConn.Open();
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                Data=new SqlDataAdapter("SELECT PriceOfDay,DataZasel FROM Rooms INNER JOIN Persons ON Persons.IdPerson='"+Surname+"' AND Persons.NumberRoom=Rooms.NumberRoom", sqlConn);
                dT=new DataTable();
                Data.Fill(dT);
     
                String str = dT.Rows[0][1].ToString();
                var parseddate=DateTime.Parse(str);
                DateTime date2 = parseddate;
                DateTime date1 = DateTime.Today;
                double sss = (date1 - date2).TotalDays;
                String buf = dT.Rows[0][0].ToString();
                double buf1=double.Parse(buf);
                double summ = sss * buf1;
                TestLabel.Content = $"{summ}$";
            }
                sqlConn.Close();
            MakeZvitBtn.IsEnabled=false;
        }

        private String[] GetItems()
        {
            String[] items = { "" };
            sqlConn.Open();
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                Data = new SqlDataAdapter("SELECT IdPerson FROM Persons WHERE Status1='True'", sqlConn);
                dT = new DataTable();
                Data.Fill(dT);
                items = new String[dT.Rows.Count];
                for (int i = 0; i < dT.Rows.Count; i++)
                {
                    items[i] = dT.Rows[i][0].ToString();
                }
            }
            sqlConn.Close();
            return items;
        }
    }
}
