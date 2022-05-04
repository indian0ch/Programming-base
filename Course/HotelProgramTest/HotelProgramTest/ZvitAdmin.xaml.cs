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
    /// Логика взаимодействия для ZvitAdmin.xaml
    /// </summary>
    public partial class ZvitAdmin : Window
    {
        SqlConnection sqlConn = new SqlConnection(@"Data Source=EXTAZ;Initial Catalog=Lab3Test;Integrated Security=True");
        SqlDataAdapter Data;
        DataTable dT = new DataTable();
        DataTable dT1 = new DataTable();
        public ZvitAdmin()
        {
            InitializeComponent();
            NumberRoomCb.ItemsSource = GetItems();
            NumberRoomCb.SelectedIndex = 0;
        }
        static long countclients=0;
        static double generalsumm=0;
        private void CreateZvitBtn_Click(object sender, RoutedEventArgs e)
        {
            sqlConn.Open();
            //
            String date1, date2,buf11,buf22;
            DateTime date11, date22,date111,date222, datevusel2;
            date1 = Calendar1.SelectedDate.ToString();
            date2 = Calendar2.SelectedDate.ToString();
            date11 = DateTime.Parse(date1);
            date22 = DateTime.Parse(date2);
            if (date11 < date22)
            {
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    String strQ = "SELECT * FROM Persons";
                    Data = new SqlDataAdapter(strQ, sqlConn);
                    dT = new DataTable();
                    Data.Fill(dT);
                    strQ = "SELECT NumberRoom, PriceOfDay FROM Rooms";
                    Data = new SqlDataAdapter(strQ, sqlConn);
                    dT1 = new DataTable();
                    Data.Fill(dT1);
                    for (int i = 0; i < dT.Rows.Count; i++)
                    {
                        date111 = date11;
                        date222 = date22;
                        String datezasel = dT.Rows[i][5].ToString();
                        DateTime datezasel2 = DateTime.Parse(datezasel);
                        String datevusel = dT.Rows[i][9].ToString();
                        //count clients
                        if (datevusel == "")
                        {
                            datevusel2 = DateTime.Today;
                            if (datezasel2 <= date111 && datevusel2 >= date222 || datezasel2 >= date111 && datevusel2 >= date222 && datezasel2 <= date222 || datezasel2 <= date111 && datevusel2 <= date222 && datevusel2 >= date111 || datezasel2 >= date111 && datevusel2 <= date222 && datezasel2 <= date222 && datevusel2 >= date111)
                            {
                                countclients++;
                            }
                        }
                        else
                        {
                            datevusel2 = DateTime.Parse(datevusel);
                            if (datezasel2 <= date111 && datevusel2 >= date222 || datezasel2 >= date111 && datevusel2 >= date222 && datezasel2 <= date222 || datezasel2 <= date111 && datevusel2 <= date222 && datevusel2 >= date111 || datezasel2 >= date111 && datevusel2 <= date222 && datezasel2 <= date222 && datevusel2 >= date111)
                            {
                                countclients++;
                            }
                        }
                        //summ
                        if (datevusel == "")
                        {
                            datevusel2 = DateTime.Today;
                            if (datezasel2 > date111 && datezasel2 > date222 && datevusel2 > date111 && datevusel2 > date222 || datezasel2 < date111 && datezasel2 < date222 && datevusel2 < date111 && datevusel2 < date222)
                            {
                            }
                            else
                            {
                                if (date111 <= datezasel2 && datevusel2 <= date222)
                                {
                                    date111 = datezasel2;
                                    date222 = datevusel2;
                                }
                                else if (date111 <= datezasel2 && date222 <= datevusel2 && datezasel2 <= date222)
                                {
                                    date111 = datezasel2;
                                }
                                else if (datezasel2 <= date111 && datevusel2 <= date222 && datevusel2 >= date111)
                                {
                                    date222 = datevusel2;
                                }
                                double sss = (date222 - date111).TotalDays;
                                for (int j = 0; j < dT1.Rows.Count; j++)
                                {
                                    buf11 = dT1.Rows[j][0].ToString();
                                    buf22 = dT.Rows[i][7].ToString();
                                    if (buf11 == buf22)
                                    {
                                        String buf = dT1.Rows[j][1].ToString();
                                        double buf1 = double.Parse(buf);
                                        double summ = sss * buf1;
                                        generalsumm += summ;
                                    }

                                }
                            }
                        }
                        else
                        {
                            datevusel2 = DateTime.Parse(datevusel);
                            if (datezasel2 > date111 && datezasel2 > date222 && datevusel2 > date111 && datevusel2 > date222 || datezasel2 < date111 && datezasel2 < date222 && datevusel2 < date111 && datevusel2 < date222)
                            {
                            }
                            else
                            {
                                if (date111 <= datezasel2 && datevusel2 <= date222)
                                {
                                    date111 = datezasel2;
                                    date222 = datevusel2;
                                }
                                else if (date111 <= datezasel2 && date222 <= datevusel2)
                                {
                                    date111 = datezasel2;
                                }
                                else if (datezasel2 <= date111 && datevusel2 <= date222)
                                {
                                    date222 = datevusel2;
                                }
                                double sss = (date222 - date111).TotalDays;
                                for (int j = 0; j < dT1.Rows.Count; j++)
                                {
                                    buf11 = dT1.Rows[j][0].ToString();
                                    buf22 = dT.Rows[i][7].ToString();
                                    if (buf11 == buf22)
                                    {
                                        String buf = dT1.Rows[j][1].ToString();
                                        double buf1 = double.Parse(buf);
                                        double summ = sss * buf1;
                                        generalsumm += summ;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("На лівому календарі повинна бути раніша дата!");
            }
            sqlConn.Close();
            CountClientLbl.Content = $"{countclients}";
            GeneralSumLbl.Content = $"{generalsumm}$";
            generalsumm = 0;
            countclients = 0;
        }
        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminPag ww;
            ww=new AdminPag();
            Hide();
            ww.Show();  
        }
        private void ZvitRoomBtn_Click(object sender, RoutedEventArgs e)
        {
            String Room=NumberRoomCb.SelectedItem.ToString();
            sqlConn.Open();
            String date1, date2;
            DateTime date11, date22, date111, date222, datevusel2,datezasel2;
            date1 = Calendar1.SelectedDate.ToString();
            date2 = Calendar2.SelectedDate.ToString();
            date11 = DateTime.Parse(date1);
            date22 = DateTime.Parse(date2);
            double countfreeday = 0;
            double countnonfreeday = 0;
            double generaldayofperiod= (date22 - date11).TotalDays;
            if (date11<date22)
            {
                Data = new SqlDataAdapter("SELECT * FROM Persons WHERE NumberRoom='"+Room+"'",sqlConn);
                dT=new DataTable();
                Data.Fill(dT);
                if(dT.Rows.Count==0)
                {
                    countfreeday = generaldayofperiod;
                }
                else
                {
                    for(int i=0;i<dT.Rows.Count;i++)
                    {
                        date111 = date11;
                        date222 = date22;
                        String datezasel = dT.Rows[i][5].ToString();
                        datezasel2=DateTime.Parse(datezasel);
                        if(dT.Rows[i][9].ToString()=="")
                        {
                            datevusel2 = DateTime.Today;
                        }
                        else
                        {
                            String datevusel=dT.Rows[i][9].ToString();
                            datevusel2=DateTime.Parse(datevusel);
                           
                        }
                        if (datezasel2 > date111 && datezasel2 > date222 && datevusel2 > date111 && datevusel2 > date222|| datezasel2 < date111 && datezasel2 < date222 && datevusel2 < date111 && datevusel2 <date222)
                        {
                            countnonfreeday += 0;
                        }
                        else
                        {
                            if (date111 <= datezasel2 && datevusel2 <= date222)
                            {
                                date111 = datezasel2;
                                date222 = datevusel2;

                            }
                            else if (date111 <= datezasel2 && date222 <= datevusel2)
                            {
                                date111 = datezasel2;

                            }
                            else if (datezasel2 <= date111 && datevusel2 <= date222)
                            {
                                date222 = datevusel2;
                            }

                            double sss = (date222 - date111).TotalDays;
                            countnonfreeday += sss;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("На лівому календарі повинна бути раніша дата!");
            }
            countfreeday= generaldayofperiod - countnonfreeday;
            CountNonFreeDayLbl.Content = $"К-сть днів, коли номер був зайнятий:{countnonfreeday}";
            CountFreeDayLbl.Content = $"К-сть днів, коли номер був вільний:{countfreeday}";
            sqlConn.Close();
        }
        private String[] GetItems()
        {
            String[] items = { "" };
            sqlConn.Open();
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                Data = new SqlDataAdapter("SELECT NumberRoom FROM Rooms", sqlConn);
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
