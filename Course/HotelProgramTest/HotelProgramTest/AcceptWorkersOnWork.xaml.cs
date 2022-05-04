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
    /// Логика взаимодействия для AcceptWorkersOnWork.xaml
    /// </summary>
    public partial class AcceptWorkersOnWork : Window
    {
        SqlConnection sqlConn = new SqlConnection(@"Data Source=EXTAZ;Initial Catalog=Lab3Test;Integrated Security=True");
        SqlCommand Com;
        SqlDataAdapter Data;
        static long LenTable;
        DataTable dT = new DataTable();
        public AcceptWorkersOnWork()
        {
            InitializeComponent();
            UpdateDataTable();
            IdWorkersCb.ItemsSource = GetItems();
            IdWorkersCb.SelectedIndex = 0;
        }

        private void AcceptBtn_Click(object sender, RoutedEventArgs e)
        {
            sqlConn.Open();
            String Id=IdTb.Text;
            String Surname=SurnameTb.Text;
            String Name=NameTb.Text;    
            String Secname=SecNameTb.Text;
            String strQ;
            if(Id!=null&& Surname!=null && Name!=null)
            {
                if(sqlConn.State==System.Data.ConnectionState.Open)
                {
                    strQ = "INSERT INTO Workers VALUES('"+Id+"','"+Surname+"','"+Name+"','"+Secname+"');";
                    Com=new SqlCommand(strQ,sqlConn);
                    Com.ExecuteNonQuery();
                    MessageBox.Show("Користувача успішно прийнято. Тепер  можете підібрати комфортний для нього графік.");
                    IdTb.Text="ID";
                    SurnameTb.Text = "Surname";
                    NameTb.Text = "Name";
                    SecNameTb.Text = "SecName";
                }
            }
            else
            {
                MessageBox.Show("Деякі з важливих полів пусті!");
            }
            sqlConn.Close();
        }

        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminPag ww;
            ww=new AdminPag();
            Hide();
            ww.Show();
        }
        String strQ;
        private void SheduleDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
           
            String NumberRoof;
            String Day;
            DataGridColumn EditedCol = e.Column;
            DataGridRow EditedRow = e.Row;
            Int32 Row = ((DataGrid)sender).ItemContainerGenerator.IndexFromContainer(EditedRow);
            Int32 Col = EditedCol.DisplayIndex;
            TextBox t = e.EditingElement as TextBox;
            String editedCellValue = t.Text.ToString();
            DataRowView row = (DataRowView)SheduleDataGrid.SelectedItem;
            NumberRoof = row["NumberRoof"].ToString();
            Day = row["DayOfWeek"].ToString();
            if (Col == 2)
            {
                strQ = "UPDATE DatesOfWork SET IdWorkers ='" + editedCellValue + "'WHERE DayOfWeek='" + Day + "' AND NumberRoof='" + NumberRoof + "';";
            }
            try
            {
                sqlConn.Open();
                Com = new SqlCommand(strQ, sqlConn);
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
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                Data = new SqlDataAdapter("Select * FROM DatesOfWork ORDER BY NumberRoof", sqlConn);
                dT = new DataTable();
                Data.Fill(dT);
                SheduleDataGrid.ItemsSource = dT.DefaultView;
                LenTable = dT.Rows.Count;
            }
            sqlConn.Close();
        }

        private void IdTb_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            IdTb.Text = "";
        }

        private void SurnameTb_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SurnameTb.Text = "";
        }

        private void NameTb_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NameTb.Text = "";
        }

        private void SecNameTb_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SecNameTb.Text = "";
        }

        private void ZvilnenaBtn_Click(object sender, RoutedEventArgs e)
        {
            String Id=IdWorkersCb.SelectedItem.ToString();
            sqlConn.Open();
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                Com = new SqlCommand("DELETE FROM Workers WHERE IdWorkers='" + Id + "'", sqlConn);
                Com.ExecuteNonQuery();
                MessageBox.Show("Службовця успішно видалено!");
            }
            sqlConn.Close();
            UpdateDataTable();
        }

        private void IdWorkersCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String id=IdWorkersCb.SelectedItem.ToString();
            sqlConn.Open();
            Data = new SqlDataAdapter("SELECT Surname,Name FROM Workers WHERE IdWorkers='"+id+"';", sqlConn);
            dT=new DataTable();
            Data.Fill(dT);
            SurnameLbl.Content = $"Surname: {dT.Rows[0][0]}";
            NameLbl.Content = $"Name: {dT.Rows[0][1]}";
            sqlConn.Close();
        }
        private String[] GetItems()
        {
            String[] items = { "" };
            sqlConn.Open();
            if(sqlConn.State==System.Data.ConnectionState.Open)
            {
                Data = new SqlDataAdapter("SELECT * FROM Workers", sqlConn);
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
    }
}
