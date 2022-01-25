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
using System.Diagnostics;
using System.IO;

namespace Prj_Soft_Protection
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }
        private void CloseStudyMode_Click(object sender, RoutedEventArgs e)
        {
            MainWindow  tt=new MainWindow();
            Hide();
            tt.Show();
        }
        private void InputField_PreviewKeyUp(object sender, KeyEventArgs e)
        {

        }
        static double[,] data = new double[3, 2];//data
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<String> slova = new List<string>();
            using (StreamReader sr = new StreamReader("Data.txt"))
            {
                while (!sr.EndOfStream)
                    slova.Add(sr.ReadLine());
            }
            string[] attempt1 = slova[0].Split(' ');
            string[] attempt2 = slova[1].Split(' ');
            string[] attempt3 = slova[2].Split(' ');
            for(int i=0;i<3;i++)
            {
                for(int j=0;j<2;j++)
                {
                    if(i==0)
                    {
                        double buf = Convert.ToDouble(attempt1[j]);
                        data[i, j] = buf;
                    }
                    if (i == 1)
                    {
                        double buf = Convert.ToDouble(attempt2[j]);
                        data[i, j] = buf;
                    }
                    if (i == 2)
                    {
                        double buf = Convert.ToDouble(attempt3[j]);
                        data[i, j] = buf;
                    }
                }    
            }
        }
        static Stopwatch stopWatch = new Stopwatch();
        static int count = 0, n = 0, m = 0;
        static double ccc = 0.0, ts = 0.0;
        double[,] inputs = new double[5, 4];//massive with time requires
        static int kupbuf = 0;
        private void InputField_KeyDown(object sender, KeyEventArgs e)
        {
            if (label != 0)
            {
                if (count == 0)
                {
                    ccc = 0;
                    ts = 0;
                    stopWatch.Start();
                    count++;
                }
                else if (count > 0 && count < 4)
                {
                    ts = stopWatch.ElapsedMilliseconds;
                    if (m == 3)
                    {
                        m = 0;
                        n++;
                        inputs[n, m] = (ts - ccc) / 1000;
                        m++;
                    }
                    else
                    {
                        inputs[n, m] = (ts - ccc) / 1000;
                        m++;
                    }
                    ccc = ts;
                    count++;
                }
                else if (count == 4)
                {
                    ts = stopWatch.ElapsedMilliseconds;
                    inputs[n, m] = (ts - ccc) / 1000;
                    stopWatch.Stop();
                    stopWatch.Reset();
                    count = 0;
                    label--;
                }
            }
        }
        static int label = 5, counter = 0, equaldisp = 0, noequaldisp = 0;
        private void InputField_KeyUp(object sender, KeyEventArgs e)
        {
            SymbolCount.Content = InputField.Text.Length;
            CountSproba.Content = $"{label}";
            if (InputField.Text != "gfhjk" && InputField.Text != "gfhj" && InputField.Text != "gfh" && InputField.Text != "gf" && InputField.Text != "g" && InputField.Text != "")
            {
                count = 0;
                m = 0;
                InputField.Text = "";
                stopWatch.Stop();
                stopWatch.Reset();
            }
            if (InputField.Text == "gfhjk")
            {
                InputField.Text = "";
                kupbuf++;
                if (label != 0)
                {
                    double summ = 0.0, summkv = 0.0;
                    for (int i = 0; i < 4; i++)
                    {
                        summ += inputs[counter, i];
                        summkv += Math.Pow(inputs[count, i], 2);
                    }
                    double mathsp = summ / 4.0, mathsp2 = summkv / 4.0;
                    double disp2 = Math.Pow(mathsp2 - mathsp, 2);
                    double smax = 0.0, smin = 0.0;
                    for (int i = 0; i < 3; i++)
                    {
                        double dispetalon =data[i, 1];
                        if (disp2 > dispetalon)
                        {
                            smax = disp2;
                            smin = dispetalon;
                        }
                        else
                        {
                            smax = dispetalon;
                            smin = disp2;
                        }
                        double Fp = smax / smin;

                        if (Fp > Fisher)
                            noequaldisp++;
                        else
                            equaldisp++;
                    }
                    if (equaldisp > noequaldisp)
                        DispField.Content = "однорідна";
                    else
                        DispField.Content = "неоднорідна";
                    counter++;
                }
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Analyz();
        }
        static double good = 0.0, errorall=0.0;
        private void Analyz()
        {
            for (int i = 0; i < 5; i++)
            {
                double summ = 0.0, summkv = 0.0;
                for (int j = 0; j < 4; j++)
                {
                    summ += inputs[i, j];
                }
                double mathspy = summ / 4;
                for (int j = 0; j < 4; j++)
                {
                    summkv += Math.Pow(inputs[i, j] - mathspy, 2);
                }
                double sy2 = summkv / 3.0;
                int error = 0;
                double buf = 0.0, s = 0.0, tp = 0.0;
                for (int j = 0; j < 3; j++)
                {
                    buf = data[j, 1];
                    s = Math.Sqrt(((buf + sy2) * 3) / 7.0);
                    tp = ((Math.Abs(data[j, 0] - mathspy)) / (s * Math.Sqrt(1.0 / 2)));
                    if (tp > Student)
                    {
                        error++;
                        errorall++;
                    }
                    else
                    {
                        good++;
                    }
                }
                double pp = (3 - error) / 3.0;
                p += pp;
                if (i == 4)
                {
                    StatisticsBlock.Content = $"{p / 5}";
                    if (textbox1.Text == "1")
                    {
                        p1 = errorall / 15;
                        P1Field.Content = $"{p1}";
                    }
                    else if (textbox1.Text == "0")
                    {
                        p2 = good / 15;
                        P2Field.Content = $"{p2}";
                    }   
                }
            }
        }
        private void User_Click(object sender, RoutedEventArgs e)
        { 
        }

        private void User_Checked(object sender, RoutedEventArgs e)
        {
        }
        static double Fisher = 9.28, p = 0.0, Student = 3.1825,p1=0.0,p2=0.0;
    }
}
