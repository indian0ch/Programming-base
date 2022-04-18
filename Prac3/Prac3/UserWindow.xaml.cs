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
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        SqlConnection sqlConn=new SqlConnection(@"Data Source=EXTAZ;Initial Catalog=Prac3;Integrated Security=True");
        SqlCommand Com;
        SqlDataAdapter Data;
        public UserWindow()
        {
            InitializeComponent();
            UpdateDataBtn.IsEnabled = false;
            this.Title = "User`s Window";
        }
        DataTable dT = new DataTable();
        int count = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sqlConn.Open();
            var loginUser = textBox_login.Text;
            var passUser = textBox_password.Text;
             Data = new SqlDataAdapter();
            if (loginUser != null)
            {
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    String strQ = "SELECT * FROM MainTable WHERE Login='" + loginUser + "';";
                    Data = new SqlDataAdapter(strQ, sqlConn);
                    dT = new DataTable("Користувачі системи");
                    Data.Fill(dT);
                    if (dT.Rows.Count == 0)
                        MessageBox.Show("Такого користувача на знайдено");
                    else
                    {
                        bool Status = Convert.ToBoolean(dT.Rows[0][4]);
                        if (!Status)
                            MessageBox.Show("Користувач заблокований Адміністратором системи!");

                        else
                        {
                            if ((dT.Rows[0][2].ToString() == loginUser) && (dT.Rows[0][3].ToString() == passUser))

                            {
                                NewNameField.Text = dT.Rows[0][0].ToString();
                                NewSurnameField.Text = dT.Rows[0][1].ToString();
                                NewPasswdField.Text = "";
                                NewPasswdField2.Text = "";
                                NewNameField.IsEnabled = true;
                                NewSurnameField.IsEnabled = true;
                                NewPasswdField.IsEnabled = true;
                                NewPasswdField2.IsEnabled = true;
                                UpdateDataBtn.IsEnabled = true;
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
                    }
                }
            }
            else
            {
                MessageBox.Show("Write a login pls!");
            }
                sqlConn.Close();
        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow ww;
            ww=new MainWindow();
            Hide();
            ww.Show();
        }

        private void UpdateDataBtn_Click(object sender, RoutedEventArgs e)
        {
            var loginUser = textBox_login.Text;
            sqlConn.Open();
            String newname = NewNameField.Text;
            String newsurname = NewSurnameField.Text;
            String newpasswd = NewPasswdField.Text;
            String newpasswd2 = NewPasswdField2.Text;
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                String strQ;
                if ((newpasswd == newpasswd2) && (newpasswd != ""))
                {
                    Boolean flag = RestrictionFunc(newpasswd);
                    if (Convert.ToBoolean(dT.Rows[0][5]) == true)
                    {
                        if (flag == true)
                        {
                            strQ = "UPDATE MainTable SET Name='" + newname + "', ";
                            strQ += "Surname='" + newsurname + "', ";
                            strQ += "Password='" + newpasswd + "' ";
                            strQ += "WHERE Login='" + loginUser + "';";
                            Com = new SqlCommand(strQ, sqlConn);
                            Com.ExecuteNonQuery();
                             NewPasswdField.Text="";
                             NewPasswdField2.Text="";
                            MessageBox.Show("Дані успішно змінено!");
                        }
                        else
                            MessageBox.Show("У паролі немає літер верхнього та нижнього регістрів, а також арифметичних операцій! Спробуйте знову!");

                    }
                    else
                    {
                        strQ = "UPDATE MainTable SET Name='" + newname + "', ";
                        strQ += "Surname='" + newsurname + "', ";
                        strQ += "Password='" + newpasswd + "' ";
                        strQ += "WHERE Login='" + loginUser + "';";
                        Com = new SqlCommand(strQ, sqlConn);
                        Com.ExecuteNonQuery();
                        MessageBox.Show("Дані успішно змінено!");
                        NewPasswdField.Text = "";
                        NewPasswdField2.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Введено пустий пароль або новий пароль повторно введено некоректно!");
                }
            }
            sqlConn.Close();
        }
        Boolean RestrictionFunc(String Pass)
        {
            Byte Count1, Count2, Count3;
            Byte LenPass = (Byte)Pass.Length;
            Count1 = Count2 = Count3 = 0;
            for (Byte i = 0; i < LenPass; i++)
            {
                if ((Convert.ToInt32(Pass[i]) >= 65) &&

                (Convert.ToInt32(Pass[i]) <= 65 + 25))

                    Count1++;
                if ((Convert.ToInt32(Pass[i]) >= 97) &&

                (Convert.ToInt32(Pass[i]) <= 97 + 25))

                    Count2++;
                if ((Pass[i] == '+') || (Pass[i] == '-') || (Pass[i] == '*') ||

                (Pass[i] == '/'))

                    Count3++;
            }
            return (Count1 * Count2 * Count3 != 0);
        }
        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            sqlConn.Open();
            String nameReg = NameField.Text;
            String surnameReg = SurnameField.Text;
            String loginReg = loginRegField.Text;
            String passwdReg = passwdRegField.Text;//pass
            String passwdReg2 = passwdRegField2.Text;//pasw
            String strQ;
            if (nameReg != null && surnameReg != null)
            {
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    try
                    {
                        if ((passwdReg == passwdReg2) && (loginReg != "") && (passwdReg != ""))
                        {
                            strQ = "INSERT INTO MainTable ";
                            strQ += "VALUES ('" + nameReg + "', '" + surnameReg +
                            "', '" + loginReg + "', '" + passwdReg + "','True', 'False'); ";
                            Com = new SqlCommand(strQ, sqlConn);
                            Com.ExecuteNonQuery();
                            MessageBox.Show("Обліковий запис успішно створено!");
                             NameField.Text="";
                             SurnameField.Text="";
                             loginRegField.Text="";
                             passwdRegField.Text="";
                             passwdRegField2.Text="";
                        }
                        else
                        {
                            MessageBox.Show("Обліковий запис не створено. Спробуйте ще раз!");
                        }
                    }
                    catch
                    {
                        //   MessageBox.Show("Користувач з таким логіном вже існує у системі!");

                    }
                }
            }
            else
            {
                MessageBox.Show("Ви щось не забули ввести!!");
            }
            sqlConn.Close();
        }
        private void OutOfSystem_Click(object sender, RoutedEventArgs e)
        {
            NewNameField.Text = "";
            NewSurnameField.Text = "";
            NewPasswdField.Text = "";
            NewPasswdField2.Text = "";
            NewNameField.IsEnabled = false;
            NewSurnameField.IsEnabled = false;
            NewPasswdField.IsEnabled = false;
            NewPasswdField2.IsEnabled = false;
            UpdateDataBtn.IsEnabled = false;
        }
    }
}
