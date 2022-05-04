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
    /// Логика взаимодействия для ChangeScheduleWorkers.xaml
    /// </summary>
    public partial class ChangeScheduleWorkers : Window
    {
        SqlConnection sqlConn = new SqlConnection(@"Data Source=EXTAZ;Initial Catalog=Lab3Test;Integrated Security=True");
        SqlCommand Com;
        SqlDataAdapter Data, Data1, Data2;
        DataTable dT = new DataTable();
        static long LenTable;
        public ChangeScheduleWorkers()
        {
            InitializeComponent();
            ChooseWorkersCb.ItemsSource = GetItems();
            ChooseWorkersCb.SelectedIndex = 0;
            UpdateDataTable();
        }

        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminPag ww;
            ww=new AdminPag();
            Hide();
            ww.Show();

        }

        private void ChooseWorkersCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ScheduleBtn_Click(object sender, RoutedEventArgs e)
        {
            String Surname=ChooseWorkersCb.SelectedItem.ToString();
            sqlConn.Open();
            Data=new SqlDataAdapter("SELECT IdWorkers FROM Workers WHERE Surname='"+Surname+"'",sqlConn);
            dT=new DataTable();
            Data.Fill(dT);
            IdLabel.Content = dT.Rows[0][0].ToString(); 
            sqlConn.Close();

        }
        String strQ;
        private void ScheduleGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            String ID;
            String Day;
            DataGridColumn EditedCol = e.Column;
            DataGridRow EditedRow = e.Row;
            Int32 Row = ((DataGrid)sender).ItemContainerGenerator.IndexFromContainer(EditedRow);
            Int32 Col = EditedCol.DisplayIndex;
            TextBox t =e.EditingElement as TextBox;
            String editedCellValue=t.Text.ToString();
            DataRowView row = (DataRowView)ScheduleGrid.SelectedItem;
            ID=row["IdWorkers"].ToString();
            Day = row["DayOfWeek"].ToString();
            if(Col==2)
            {
                strQ = "UPDATE DatesOfWork SET IdWorkers ='" + editedCellValue + "'WHERE DayOfWeek='" + Day + "' AND IdWorkers='" + ID + "';";
            }
            try
            {
                sqlConn.Open();
                Com=new SqlCommand(strQ,sqlConn);
                Com.ExecuteNonQuery().ToString();

                sqlConn.Close();
                MessageBox.Show("Success");
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void UpdateDataTable()
        {
            sqlConn.Open();
            if(sqlConn.State==System.Data.ConnectionState.Open)
            {
                Data=new SqlDataAdapter("Select * FROM DatesOfWork ORDER BY IdWorkers", sqlConn);
                dT=new DataTable();
                Data.Fill(dT);
                ScheduleGrid.ItemsSource = dT.DefaultView;
                LenTable = dT.Rows.Count;
            }
            sqlConn.Close ();
        }
       private String [] GetItems()
        {
            String[] Items = { "" };
            sqlConn.Open();
            if(sqlConn.State==System.Data.ConnectionState.Open)
            {
                Data = new SqlDataAdapter("SELECT * FROM Workers", sqlConn);
                dT=new DataTable();
                Data.Fill(dT);
                Items=new String[dT.Rows.Count];
                for(int i=0;i<dT.Rows.Count;i++)
                {
                    Items[i]=dT.Rows[i][1].ToString();
                }
            }
            sqlConn.Close();
            return Items;
                
        }
    }
}
