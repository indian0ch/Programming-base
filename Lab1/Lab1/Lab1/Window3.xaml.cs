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

namespace Lab1
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        string first="",second="",number="";
        char function;
        double result = 0.0;
        double firstd = 0.0;
        int k = 0,o=0;
        public Window3()
        {
            InitializeComponent();
        }
        /*
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw;
            mw = new MainWindow();
            Hide();
            mw.Show();
        }
        */
        private void Button_Click_1(object sender, RoutedEventArgs e)//home
        {
            MainWindow mw;
            mw = new MainWindow();
            Hide();
            mw.Show();
        }
        private void btn1_Click(object sender, RoutedEventArgs e)//1
        {
            TextForm.Text = "";
            number += "1";
            TextForm.Text += number;
        }
        private void btn2_Click(object sender, RoutedEventArgs e)//2
        {
            TextForm.Text = "";
            number += "2";
            TextForm.Text += number;
        }
        private void btn3_Click(object sender, RoutedEventArgs e)//3
        {
            TextForm.Text = "";
            number += "3";
            TextForm.Text += number;
        }
        private void btn4_Click(object sender, RoutedEventArgs e)//4
        {
            TextForm.Text = "";
            number += "4";
            TextForm.Text += number;
        }
        private void btn6_Click(object sender, RoutedEventArgs e)//6
        {
            TextForm.Text = "";
            number += "6";
            TextForm.Text += number;
        }
        private void btn5_Click(object sender, RoutedEventArgs e)//5
        {
                TextForm.Text = "";
            number += "5";
                TextForm.Text += number;
        }
        private void btnEquals_Click(object sender, RoutedEventArgs e)//=
        {
            if (number == "")
            {
                TextForm.Text = "Write number";
            }
            else
            {
                if (k == 0)
                {
                    second = number;
                    double num1, num2;
                    num1 = Convert.ToDouble(first);
                    num2 = Convert.ToDouble(second);
                    double q;
                    q = Obrax(num1, num2);
                    TextForm.Text = q.ToString();
                    function = ' ';
                    firstd = q;
                    number = "";
                    k++;
                }
                else
                {
                    second = number;
                    double num11, num22;
                    num11 = firstd;
                    num22 = Convert.ToDouble(second);
                    double qq;
                    qq = Obrax(num11, num22);
                    firstd = qq;
                    TextForm.Text = qq.ToString();
                    number = "";
                    k++;
                    function = ' ';
                }
                o = 0;
            }
        }
        public  double Obrax(double num1,double num2)//функція для обрахунків значень потріних чисел
        {
            double result=0.0;
            if (function == '+')
                result = num1 + num2;
            else if (function == '-')
                result = num1 - num2;
            else if (function == '/')
            {
                if (num2 == '0')
                    TextForm.Text = "Error";
                else
                    result = num1 / num2;
            }
            else if (function == '*')
                result = num1 * num2;
            return result;
        }
        private void plus_Click(object sender, RoutedEventArgs e)//+
        {
                function = '+';
                first = number;
                number = "";
                o = 0;
        }
        private void minus_Click(object sender, RoutedEventArgs e)//-
        {
            function = '-';
            first = number;
            number = "";
            o = 0;
        }
        private void btn0_Click(object sender, RoutedEventArgs e)//0
        {
            TextForm.Text = "";
            number += "0";
            TextForm.Text += number;
        }
        private void btnComa_Click(object sender, RoutedEventArgs e)//,
        {
            if(o==0)//більше однієї коми в цифрі неможливо
            {
                TextForm.Text = "";
                number += ".";
                TextForm.Text += number;
                o++;
            }
        }
        private void divide_Click(object sender, RoutedEventArgs e)// /
        {
            function = '/';
            first = number;
            number = "";
            o = 0;
        }
        private void multiple_Click(object sender, RoutedEventArgs e)//*
        {
            function = '*';
            first = number;
            number = "";
            o = 0;
        }
        private void btn8_Click(object sender, RoutedEventArgs e)//8
        {
            TextForm.Text = "";
            number += "8";
            TextForm.Text += number;
        }
        private void Button_Click(object sender, RoutedEventArgs e)//-(number)
        {
            if(number != "")
            {
                TextForm.Text = "";
                double num1;
                num1 = Convert.ToDouble(number);
                num1 *= -1;
                number = Convert.ToString(num1);
                TextForm.Text += number;
            }
            else
                TextForm.Text = "Введіть спочатку число";
        }
        private void clearall_Click(object sender, RoutedEventArgs e)//clear
        {
            first = "";
            second = "";
            TextForm.Text = "";
            number = "";
            result = 0.0;
            o = 0;
            k = 0;
        }
        private void btn7_Click(object sender, RoutedEventArgs e)//7
        {
            TextForm.Text = "";
            number += "7";
            TextForm.Text += number;
        }
        private void btn9_Click(object sender, RoutedEventArgs e)//9
        {
            TextForm.Text = "";
            number += "9";
            TextForm.Text += number;
        }
    }
}
