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
    /// Логика взаимодействия для PoselVuselClients.xaml
    /// </summary>
    public partial class PoselVuselClients : Window
    {
        SqlConnection sqlConn = new SqlConnection(@"Data Source=EXTAZ;Initial Catalog=Lab3Test;Integrated Security=True");
        SqlCommand Com,Com1;
        SqlDataAdapter Data, Data1, Data2;
        DataTable dT = new DataTable();
        public PoselVuselClients()
        {
            InitializeComponent();
            FreeRoomCb.ItemsSource = GetItemsR();
            FreeRoomCb.SelectedIndex = 0;
            VuselIdCb.ItemsSource = GetItemsVusel();
            VuselIdCb.SelectedIndex = 0;
        }

        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminPag ww;
            ww=new AdminPag();
            Hide();
            ww.Show();
        }

        private void PoselBtn_Click(object sender, RoutedEventArgs e)
        {
            
            String Room = FreeRoomCb.SelectedItem.ToString();
            String Surname = SurnameTb.Text;
            String Name = NameTb.Text;
            String SecName=SecnameTb.Text;
            String ID=IdTb.Text;
            String City=CityTb.Text;
            String Password=PasswordTb.Text;
            String Status = "True";
            DateTime dt=DateTime.Today;
           // DateTime date = dt.Date;
            String DataZasel=$"{dt.ToString("MM'/'dd'/'yyyy")}";
            String strQ,strQ1;
            sqlConn.Open();
            if (Surname!=null&& Name!=null&&City!=null&&ID!=null)
            {
                if(sqlConn.State==System.Data.ConnectionState.Open)
                {
                   
                        strQ = "INSERT INTO Persons ";
                        strQ += "VALUES('" + ID + "','" + Surname + "','" + Name + "','" + SecName + "','" + City + "','" + DataZasel + "','" + Password + "','" + Room + "','True',NULL);";
                        Com1 = new SqlCommand(strQ, sqlConn);
                        Com1.ExecuteNonQuery();
                        strQ1 = "UPDATE Rooms SET Status2 = '" + Status + "' WHERE NumberRoom = '" + Room + "';";
                        Com = new SqlCommand(strQ1, sqlConn);
                        Com.ExecuteNonQuery();
                        SurnameTb.Text = "Surname";
                        NameTb.Text = "Name";
                        SecnameTb.Text = "SecName";
                        CityTb.Text = "City";
                        IdTb.Text = "ID";
                        PasswordTb.Text = "Password";
                        MessageBox.Show("Complete!");
                    /*
                    catch
                    {
                        MessageBox.Show("Error!");
                    }
                    */
                }
            }
            else
            {
                MessageBox.Show("Ви не заповнили деякі пункти!");
            }
            sqlConn.Close();
        }
        private void VuselBtn_Click(object sender, RoutedEventArgs e)
        {
            String ID =VuselIdCb.SelectedItem.ToString();
            DateTime dt = DateTime.Today;
            String DataVusel = $"{dt.ToString("MM'/'dd'/'yyyy")}";
            String strQ;
            sqlConn.Open();
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                 strQ = "UPDATE Persons SET Status1='False', DataVusel='"+DataVusel+"' WHERE IdPerson='"+ID+"';";
                Com=new SqlCommand(strQ, sqlConn);
                Com.ExecuteNonQuery();
                strQ = "UPDATE Rooms SET Status2='False' WHERE NumberRoom=(SELECT NumberRoom FROM Persons WHERE IdPerson='"+ID+"');";
                Com=new SqlCommand(strQ, sqlConn);
                Com.ExecuteNonQuery();
                MessageBox.Show("Клієнт виселений!");
            }
                sqlConn.Close();
        }
        private void FreeRoomCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String Text=FreeRoomCb.SelectedItem.ToString();
            sqlConn.Open();
            Data = new SqlDataAdapter("SELECT Type, PriceOfDay FROM Rooms WHERE NumberRoom='"+Text+"'",sqlConn);
            dT=new DataTable();
            Data.Fill(dT);
            TypeLbl.Content = $"{dT.Rows[0][0]}";
            PriceLbl.Content = $"{dT.Rows[0][1]}";
            sqlConn.Close();
        }

        private void SurnameTb_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SurnameTb.Text = null;
        }

        private void IdTb_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            IdTb.Text = "";
        }

        private void NameTb_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NameTb.Text = null;
        }

        private void CityTb_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            CityTb.Text = null;
        }

        private void SecnameTb_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SecnameTb.Text=null;
        }

        private void PasswordTb_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            PasswordTb.Text = null;
        }

        private void VuselIdCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String Surname=VuselIdCb.SelectedItem.ToString();
            sqlConn.Open();
            Data = new SqlDataAdapter("SELECT Surname,Name,NumberRoom FROM Persons WHERE IdPerson='"+Surname+"';",sqlConn);
            dT=new DataTable();
            Data.Fill(dT);
            IdLbl.Content = $"{dT.Rows[0][0]}";
            NameLbl.Content = $"{dT.Rows[0][1]}";
            RoomLbl.Content = $"{dT.Rows[0][2]}";
            sqlConn.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private String [] GetItemsR()
        {
            String[] items = { "" };
            sqlConn.Open();
            if(sqlConn.State==System.Data.ConnectionState.Open)
            {
                Data = new SqlDataAdapter("SELECT NumberRoom FROM Rooms WHERE Status2='False'",sqlConn);
                dT=new DataTable();
                Data.Fill(dT);
                items=new String[dT.Rows.Count];
                for(int i=0;i<dT.Rows.Count;i++)
                {
                    items[i]=dT.Rows[i][0].ToString();
                }
            }
            sqlConn.Close();
            return items;
        }
        private String[] GetItemsVusel()
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
