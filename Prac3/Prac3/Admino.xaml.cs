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

namespace Prac3
{
    /// <summary>
    /// Логика взаимодействия для Admino.xaml
    /// </summary>
    public partial class Admino : Window
        
    {
        
        SqlConnection sqlConn = new SqlConnection(@"Data Source=EXTAZ;Initial Catalog=Prac3;Integrated Security=True");
        SqlCommand Com;
        SqlDataAdapter Data;
        DataTable dT = new DataTable();
        static int LenTable;
        public Admino()
        {
            InitializeComponent();
            this.Title = "Admin`s Window";
            RealAdminPasswd.Text = ""; RealAdminPasswd.IsEnabled = false;
            NewAdminPasswd.Text = ""; NewAdminPasswd.IsEnabled = false;
            NewAdminPasswd2.Text = ""; NewAdminPasswd2.IsEnabled = false;
            Prev.IsEnabled = false; Next.IsEnabled = false;
            UpdatePasswd.IsEnabled = false;
            AddUser.IsEnabled = false;
            CorrectStatusBtn.IsEnabled = false;
            CorrectRestrictionBtn.IsEnabled = false;
            UpdateDataTable();
            UsersLogins.ItemsSource = GetItems();
            UsersLogins.SelectedIndex = 0;
            index = -1;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ww;
            ww=new MainWindow();
            Hide();
            ww.Show();
        }
        string pswadm;
        private void UpdatePasswd_Click(object sender, RoutedEventArgs e)
        {
            String strQ;
            String RealPass = RealAdminPasswd.Text.ToString();//password
            String NewPass = NewAdminPasswd.Text.ToString();
            String NewPass2 = NewAdminPasswd2.Text.ToString();
            if ((RealPass == pswadm) && (NewPass != "") && (NewPass == NewPass2))
            {
                sqlConn.Open();
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    strQ = "UPDATE MainTable SET Password ='" + NewPass + "' WHERE Login = 'admin'; ";
                Com = new SqlCommand(strQ, sqlConn);
                    Com.ExecuteNonQuery();
                    MessageBox.Show("Password changed");
                    NewAdminPasswd2.Text="";
                    NewAdminPasswd.Text = "";
                    RealAdminPasswd.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Smt wrong!");
            }
            sqlConn.Close();
        }
        int buf = 1;
        private void UpdateDataTable()
        {
            sqlConn.Open();
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                Data = new SqlDataAdapter("SELECT Name, Surname, Login, Status, Restriction FROM MainTable", sqlConn);
                dT = new DataTable("Користувачі системи");
                Data.Fill(dT);
                dataGrid.ItemsSource = dT.DefaultView;
                LenTable = dT.Rows.Count;
            }
            sqlConn.Close();
        }
        private void Prev_Click(object sender, RoutedEventArgs e)
        {
            sqlConn.Open();
            if (index > 0&&dT.Rows.Count>0)
            {
                index--;
                UserNameSelected.Content = dT.Rows[index][0].ToString();
                UserSurnameSelected.Content = dT.Rows[index][1].ToString();
                UserLoginSelected.Content = dT.Rows[index][2].ToString();
                UserStatusSelected.Content = dT.Rows[index][3].ToString();
                UserRestrictionSelected.Content = dT.Rows[index][4].ToString();
            }
            sqlConn.Close();
        }
         int index = -1;

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            sqlConn.Open();
            Data = new SqlDataAdapter("SELECT Name, Surname, Login, Status, Restriction FROM MainTable", sqlConn);
            dT = new DataTable("Користувачі системи");
            Data.Fill(dT);
            dataGrid.ItemsSource = dT.DefaultView;
            LenTable = dT.Rows.Count;
            if (index < LenTable - 1)
            {
                index++;
                UserNameSelected.Content = dT.Rows[index][0].ToString();
                UserSurnameSelected.Content = dT.Rows[index][1].ToString();
                UserLoginSelected.Content = dT.Rows[index][2].ToString();
                UserStatusSelected.Content = dT.Rows[index][3].ToString();
                UserRestrictionSelected.Content = dT.Rows[index][4].ToString();
            }
            sqlConn.Close();
        }
        private void UsersLogins_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String Text = UsersLogins.SelectedItem.ToString();
            sqlConn.Open();
            Data = new SqlDataAdapter("SELECT  Login,Status,Restriction From MainTable;", sqlConn);
            dT = new DataTable("Користувачі системи");
            Data.Fill(dT);
            for (int i = 0; i < dT.Rows.Count; i++)
            {
              String tempStr = dT.Rows[i][0].ToString();
                if (Text == tempStr)
                {
                  //  IDdistrict = dT.Rows[i][0].ToString();
                    if(dT.Rows[i][1].ToString()==checking)
                        ChangeActive.IsChecked = true; 
                  else if(dT.Rows[i][1].ToString()==checkingf)
                        ChangeActive.IsChecked = false;
                    if (dT.Rows[i][2].ToString() == checking)
                        ChangeRestriction.IsChecked = true;
                    else if (dT.Rows[i][2].ToString() == checkingf)
                        ChangeRestriction.IsChecked = false;  
                }
            }
            sqlConn.Close();
        }
        string checking="True";
        string checkingf = "False";
        private void CorrectStatusBtn_Click(object sender, RoutedEventArgs e)
        {
            sqlConn.Open();
            String strQ;
            bool UserStatus = (bool)ChangeActive.IsChecked;
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                strQ = "UPDATE MainTable SET Status ='" + UserStatus + "' WHERE Login='" + UsersLogins.SelectedValue.ToString() + "';";
                Com = new SqlCommand(strQ, sqlConn);
                Com.ExecuteNonQuery();
            }
            sqlConn.Close();
            UpdateDataTable();
        }
        private void CorrectRestrictionBtn_Click(object sender, RoutedEventArgs e)
        {
            
            sqlConn.Open();
            String strQ;
            bool UserRestriction = (bool)ChangeRestriction.IsChecked;
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                strQ = "UPDATE MainTable SET Restriction ='" + UserRestriction + "' WHERE Login = '" + UsersLogins.SelectedValue.ToString() + "'; ";
                Com = new SqlCommand(strQ, sqlConn);
                Com.ExecuteNonQuery();
            }
            sqlConn.Close();
            UpdateDataTable(); 
        }
        private void ExitFromSystem_Click(object sender, RoutedEventArgs e)
        {
            RealAdminPasswd.Text = ""; RealAdminPasswd.IsEnabled = false;
            NewAdminPasswd.Text = ""; NewAdminPasswd.IsEnabled = false;
            NewAdminPasswd2.Text = ""; NewAdminPasswd2.IsEnabled = false;
            Prev.IsEnabled = false; Next.IsEnabled = false;
            UpdatePasswd.IsEnabled = false;
            AddUser.IsEnabled = false;
            CorrectStatusBtn.IsEnabled = false;
            CorrectRestrictionBtn.IsEnabled = false;
            AdminPasswd.Text = "";
            buf = 1;
        }
        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            sqlConn.Open();
            String strQ;
            String UserLogin = AddingUserLogin.Text;
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                    strQ = "INSERT INTO MainTable (Name, Surname, Login, Status,Restriction) values('', '', '" + UserLogin + "', 1, 0); ";
                    Com = new SqlCommand(strQ, sqlConn);
                    Com.ExecuteNonQuery();
                    MessageBox.Show("User succesfully adding!");
            }
                
            sqlConn.Close();
            UpdateDataTable();
        }
        static int count = 0;
        string psw;
        private void AuthoriseBtn_Click(object sender, RoutedEventArgs e)
        {
            sqlConn.Open();
            var passAdm = AdminPasswd.Text;
            Data = new SqlDataAdapter();
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                String strQ = "SELECT * FROM MainTable WHERE Login= 'admin' ;";
                Data = new SqlDataAdapter(strQ, sqlConn);
                dT = new DataTable("Користувачі системи");
                Data.Fill(dT);
                if  (dT.Rows[0][3].ToString() == passAdm)
                {
                    RealAdminPasswd.Text = ""; RealAdminPasswd.IsEnabled = true;
                    NewAdminPasswd.Text = ""; NewAdminPasswd.IsEnabled = true;
                    NewAdminPasswd2.Text = ""; NewAdminPasswd2.IsEnabled = true;
                    Prev.IsEnabled = true; Next.IsEnabled = true;
                    UpdatePasswd.IsEnabled = true;
                    AddUser.IsEnabled = true;
                    CorrectStatusBtn.IsEnabled = true;
                    CorrectRestrictionBtn.IsEnabled = true;
                    count = 0;
                    psw = dT.Rows[0][3].ToString();
                    pswadm = passAdm;
                    buf = 0;
                }
                else
                {
                     count++;
                     String s = "Невірно введений пароль! " + "Помилкове введення No" + count.ToString();
                     MessageBox.Show(s);
                     if (count == 3)
                            System.Windows.Application.Current.Shutdown();
                }
            }
            sqlConn.Close();
        }
        String strQ;
        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (buf == 0)
            {
                String ID;
                DataGridColumn EditedCol = e.Column;
                DataGridRow EditedRow = e.Row;
                Int32 Row = ((DataGrid)sender).ItemContainerGenerator.IndexFromContainer(EditedRow);
                Int32 Col = EditedCol.DisplayIndex;
                TextBox t = e.EditingElement as TextBox;
                String editedCellValue = t.Text.ToString();
                DataRowView row = (DataRowView)dataGrid.SelectedItem;
                ID = row["Login"].ToString();
                if (Col == 0)
                    strQ = "UPDATE MainTable SET Name = '" + editedCellValue + "' WHERE Login = '" + ID + "';";
                else if (Col == 1)
                    strQ = "UPDATE MainTable SET Surname = '" + editedCellValue + "' WHERE Login = '" + ID + "';";
                try
                {
                    sqlConn.Open();
                    Com = new SqlCommand(strQ, sqlConn);
                    Com.ExecuteNonQuery().ToString();
                    sqlConn.Close();
                    MessageBox.Show("Дані успішно змінено");
                }
                catch
                {
                    MessageBox.Show("Data  not changed. Sorry Dude^(");
                }
            }
            else
            {
                MessageBox.Show("Authorization first");
            }
        }
       // String IDdistrict = "1";
        private String[] GetItems()
        {
            String[] Items = { "" };
            sqlConn.Open();
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                Data = new SqlDataAdapter("SELECT * FROM MainTable", sqlConn);
                dT = new DataTable("T");
                Data.Fill(dT);
                Items = new String[dT.Rows.Count];
                for (int i = 0; i < dT.Rows.Count; i++)
                {
                    Items[i] = dT.Rows[i][2].ToString();
                }
            }
            sqlConn.Close();
            return Items;
        }
        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
        private void dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
        }
    }
}
