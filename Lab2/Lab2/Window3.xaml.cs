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

namespace Lab2
{

    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        string first = "", second = "", number = "";
        char function;
        double result = 0.0;
        double firstd = 0.0;
        int k = 0, o = 0;
        static int M = 7;
        static int N = 4;
        Grid myGrid;
        TextBox TextForm;
        Label lbl;
        public Window3()
        {
            InitializeComponent();
            initControls();
        }
        static int buf = 1;
        private void initControls()
        {
            this.Title = "Calculator|Window3";
            // this.ResizeMode = ResizeMode.NoResize;
            myGrid = new Grid();
            myGrid.Width = 550;
            myGrid.Height = 650;
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;
            myGrid.ShowGridLines = false;
            Button[,] ArrBtn = new Button[M, N];
            this.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF36628E"));
            for (int i = 2; i < M - 1; i++)
            {
                for (int j = 0; j < N - 1; j++)
                {
                    ArrBtn[i, j] = new Button();
                    ArrBtn[i, j].Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFA31B"));
                    ArrBtn[i, j].Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF3E4E4"));
                    ArrBtn[i, j].FontSize = 36;
                    ArrBtn[i, j].FontFamily = new FontFamily("Gabriola");
                    if (i == M - 2 && j == 0)
                    {
                        ArrBtn[i, j].Content = "0";
                        ArrBtn[i, j].Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3D3D3D"));
                        ArrBtn[i, j].Click += Btn0_Click;
                    }
                    else if (i == M - 2 && j == 1)
                    {
                        ArrBtn[i, j].Content = "+";
                        ArrBtn[i, j].Click += plus_Click;
                    }
                    else if (i == M - 2 && j == 2)
                    {
                        ArrBtn[i, j].Content = "-";
                        ArrBtn[i, j].Click += minus_Click;
                    }
                    else if (i == M - 2 && j == 3)
                    {
                        ArrBtn[i, j].Content = ".";
                        ArrBtn[i, j].Click += btnComa_Click;
                    }
                    else
                    {
                        ArrBtn[i, j].Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3D3D3D"));
                        ArrBtn[i, j].Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF3E4E4"));
                        ArrBtn[i, j].Content = $"{buf}";
                        ArrBtn[i, j].Name = $"Btn{buf}";
                        if (buf == 9)
                            buf = 1;
                        else
                            buf++;
                    }
                }
            }
            for (int i = 2; i < M - 1; i++)
            {
                for (int j = 0; j < N - 1; j++)
                {
                    if (ArrBtn[i, j].Name =="Btn1")
                    {
                        ArrBtn[i, j].Click += Btn1_Click;
                    }
                    else if (ArrBtn[i, j].Name == "Btn2")
                    {
                        ArrBtn[i, j].Click += Btn2_Click;
                    }
                    else if (ArrBtn[i, j].Name == "Btn3")
                    {
                        ArrBtn[i, j].Click += Btn3_Click;
                    }
                    else if (ArrBtn[i, j].Name == "Btn4")
                    {
                        ArrBtn[i, j].Click += Btn4_Click;
                    }
                    else if (ArrBtn[i, j].Name == "Btn5")
                    {
                        ArrBtn[i, j].Click += Btn5_Click;
                    }
                    else if (ArrBtn[i, j].Name == "Btn6")
                    {
                        ArrBtn[i, j].Click += Btn6_Click;
                    }
                    else if (ArrBtn[i, j].Name == "Btn7")
                    {
                        ArrBtn[i, j].Click += Btn7_Click;
                    }
                    else if (ArrBtn[i, j].Name == "Btn8")
                    {
                        ArrBtn[i, j].Click += Btn8_Click;
                    }
                    else if (ArrBtn[i, j].Name == "Btn9")
                    {
                        ArrBtn[i, j].Click += Btn9_Click;
                    }
                }
            }
            RowDefinition[] rows = new RowDefinition[M];
            ColumnDefinition[] cols = new ColumnDefinition[N];
            for (int i = 0; i < M; i++)
            {
                rows[i] = new RowDefinition();
                myGrid.RowDefinitions.Add(rows[i]);
            }
            for (int i = 0; i < N; i++)
            {
                cols[i] = new ColumnDefinition();
                myGrid.ColumnDefinitions.Add(cols[i]);
            }
            for (int i = 2; i < M - 1; i++)
                for (int j = 0; j < N - 1; j++)
                {
                    Grid.SetRow(ArrBtn[i, j], i);
                    Grid.SetColumn(ArrBtn[i, j], j);
                }
            Buttons();
            Labels();
            TextForms();
            for (int i = 2; i < M - 1; i++)
                for (int j = 0; j < N - 1; j++)
                    myGrid.Children.Add(ArrBtn[i, j]);
            this.Content = myGrid; // this.Content = myGrid;
            this.Show();
        }
        private void TextForms()
        {
            TextForm = new TextBox();
            TextForm.HorizontalAlignment = HorizontalAlignment.Center;
            TextForm.VerticalAlignment = VerticalAlignment.Center;
            TextForm.Width = 415;
            TextForm.Height = 108;
            TextForm.FontSize = 44;
            TextForm.FontFamily = new FontFamily("Cambria Math");
            TextForm.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF1F1F1F"));
            TextForm.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFE2E2"));
            Grid.SetRow(TextForm, 1);
            Grid.SetColumnSpan(TextForm, 3);
            myGrid.Children.Add(TextForm);
        }
        private void Labels()
        {
            lbl = new Label();
            lbl.Content = "Simple Calculator";
            lbl.FontSize = 46;
            lbl.FontFamily = new FontFamily("Gabriola");
            lbl.HorizontalAlignment = HorizontalAlignment.Center;
            lbl.VerticalAlignment = VerticalAlignment.Center;
            lbl.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF36628E"));
            lbl.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFE2E2"));
            Grid.SetRow(lbl, 0);
            Grid.SetColumnSpan(lbl, 4);
            myGrid.Children.Add(lbl);
        }
        private void Buttons()
        {
            Button Btn = new Button();
            Button Btndi = new Button();
            Button BtnEq = new Button();
            Button c = new Button();
            Button znak = new Button();
            Button coma = new Button();
            Button Btnml = new Button();
            Button[] btns = new Button[]{ Btn, Btndi, BtnEq, c,znak,coma,Btnml};
            coma.Content = ".";
            znak.Content = "+/-";
            c.Content = "C";
            Btn.Content = "Back Home";
            c.Click += clearall_Click;
            Btn.Click += Btn_Click;
            znak.Click += Button_Click;
            BtnEq.Content = "=";
            Btndi.Content = "/";
            BtnEq.Click += btnEquals_Click;
            Btndi.Click += divide_Click;
            coma.Click += btnComa_Click;
            Btnml.Click += multiple_Click;
            Btnml.Content = "*";
            Btn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF31313"));
            Btn.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF3E4E4"));
            for (int i = 0; i < btns.Length; i++)
            {
                if(btns[i]==c|| btns[i] == coma|| btns[i] == Btndi || btns[i] == Btnml )
                {
                    btns[i].Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF3E4E4"));
                    btns[i].Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFA31B"));
                }
                else if(btns[i]==BtnEq||btns[i]==znak)
                {
                    btns[i].Background = Brushes.Black;
                    btns[i].Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF3E4E4"));
                }
                btns[i].FontSize = 36;
                btns[i].FontFamily = new FontFamily("Gabriola");
            }
            Btn.FontSize = 16;
            Grid.SetRow(znak, 6);
            Grid.SetColumnSpan(znak, 2);
            Grid.SetColumn(znak, 2);
            Grid.SetRow(coma, 5);
            Grid.SetColumn(coma, 4);
            Grid.SetRow(Btndi, 2);
            Grid.SetColumn(Btndi, 3);
            Grid.SetRow(Btnml, 3);
            Grid.SetColumn(Btnml, 3);
            Grid.SetRow(c, 4);
            Grid.SetColumn(c, 4);
            Grid.SetRow(BtnEq, 6);
            Grid.SetColumnSpan(BtnEq, 2);
            Grid.SetRow(Btn, 1);
            Grid.SetColumn(Btn, 4);
            for(int i=0;i<btns.Length;i++)
                myGrid.Children.Add(btns[i]);
        }
        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow wm = new MainWindow();
            Hide();
            wm.Show();
        }
        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            TextForm.Text = "";
            number += "1";
            TextForm.Text += number;
        }
        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            TextForm.Text = "";
            number += "2";
            TextForm.Text += number;
        }
        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            TextForm.Text = "";
            number += "3";
            TextForm.Text += number;
        }
        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            TextForm.Text = "";
            number += "4";
            TextForm.Text += number;
        }
        private void Btn5_Click(object sender, RoutedEventArgs e)
        {
            TextForm.Text = "";
            number += "5";
            TextForm.Text += number;
        }
        private void Btn6_Click(object sender, RoutedEventArgs e)
        {
            TextForm.Text = "";
            number += "6";
            TextForm.Text += number;
        }
        private void Btn7_Click(object sender, RoutedEventArgs e)
        {
            TextForm.Text = "";
            number += "7";
            TextForm.Text += number;
        }
        private void Btn8_Click(object sender, RoutedEventArgs e)
        {
            TextForm.Text = "";
            number += "8";
            TextForm.Text += number;
        }
        private void Btn9_Click(object sender, RoutedEventArgs e)
        {
            TextForm.Text = "";
            number += "9";
            TextForm.Text += number;
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
        private void Btn0_Click(object sender, RoutedEventArgs e)
        {
            TextForm.Text = "";
            number += "0";
            TextForm.Text += number;
        }
        public double Obrax(double num1, double num2)//функція для обрахунків значень потріних чисел
        {
            double result = 0.0;
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
        private void btnComa_Click(object sender, RoutedEventArgs e)//,
        {
            if (o == 0)//більше однієї коми в цифрі неможливо
            {
                TextForm.Text = "";
                number += ",";
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

        private void Window2_SizeChanged_1(object sender, SizeChangedEventArgs e)
        {
            double val = Math.Max(1.0 * 550 / this.Width, 1.0 * 650 / this.Height);
            lbl.FontSize   = (int)(1.0 * 46/ val);
            myGrid.Width = (int)(1.0 * 550 / val);
            myGrid.Height = (int)(1.0 * 650 / val);
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
        private void Button_Click(object sender, RoutedEventArgs e)//-(number)
        {
            if (number != "")
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
    }
}
