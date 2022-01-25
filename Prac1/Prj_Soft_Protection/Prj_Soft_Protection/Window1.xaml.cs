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
using System.Threading;
using System.IO;


namespace Prj_Soft_Protection
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        //static StreamWriter MyFileG;
        public Window1()
        {
            InitializeComponent();
        }
        double[,] inputs = new double[3,4];
        int[] sprobaperezap = new int[3];
        private void CloseStudyMode_Click(object sender, RoutedEventArgs e)
        {
            MainWindow rr=new MainWindow();
            Hide();
            rr.Show();
        }
        static int kupbuf = 0;
        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            SymbolCount.Content = Inputf.Text.Length;
            if (Inputf.Text=="gfhjk")
            {
                Inputf.Text = "";
                CountSproba.Content = $"{label}";
                kupbuf++;
            }
           if(Inputf.Text != "gfhjk"&& Inputf.Text != "gfhj"&& Inputf.Text != "gfh"&& Inputf.Text != "gf"&& Inputf.Text != "g"&&Inputf.Text !="")
            {
                count = 0;
                m = 0;
                Inputf.Text="";
                stopWatch.Stop();
                stopWatch.Reset();
            }
        }
        static int n = 0,m=0;
        private void BaseinFile(double elapsedTime, object sender, RoutedEventArgs e)//temporary
        {
            try
            {
                using (StreamWriter MyFileG = new StreamWriter("G.txt", true, System.Text.Encoding.Default))
                {
                    MyFileG.WriteLine($"{elapsedTime/1000}");
                    MyFileG.Close();
                }
            }
            catch (Exception ex)
            {
                Inputf.Text = (ex.Message);
            }
        }
        static Stopwatch stopWatch = new Stopwatch();
        static int count = 0, perezap = 0,label=3;
        static double ccc = 0.0, ts = 0.0;
        private void Inputf_KeyDown(object sender, KeyEventArgs e)
        {
            if (label != 0)
            {
                if (perezap == 0)
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
                        BaseinFile(ts - ccc, sender, e);
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
                        BaseinFile(ts - ccc, sender, e);
                        inputs[n, m] = (ts - ccc) / 1000;
                        stopWatch.Stop();
                        stopWatch.Reset();
                        count = 0;
                        label--;
               
                    }
                }
                else
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
                        BaseinFile(ts - ccc, sender, e);
                        if (m == 3)
                        {
                            m = 0;
                            // n++;
                            inputs[sprobaperezap[perezap - 1], m] = (ts - ccc) / 1000;
                            m++;
                        }
                        else
                        {
                            inputs[sprobaperezap[perezap - 1], m] = (ts - ccc) / 1000;
                            m++;
                        }
                        ccc = ts;
                        count++;
                    }
                    else if (count == 4)
                    {
                        ts = stopWatch.ElapsedMilliseconds;
                        BaseinFile(ts - ccc, sender, e);
                        inputs[sprobaperezap[perezap - 1], m] = (ts - ccc) / 1000;
                        stopWatch.Stop();
                        stopWatch.Reset();
                        count = 0;
                        label--;
                        countsp--;
                        perezap--;
                    }
                }
            }
        }
        static double Student = 4.3027;
        static double mathsp = 0.0, mathdisp = 0.0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Znachustsi(inputs[i, j], i, j);
                }
            }
        }
        private void Znachustsi(double time,int i,int j)
        {
            double summ = 0.0, buf = 0.0, summ2 = 0.0;
            int counts = 0;
                for(int m=0;m<4;m++)
                {
                    if(m==j)
                    {
                        summ+=0;
                    }
                    else
                    {
                        summ += inputs[i, m];
                        counts++;
                    }
                    
                }
            mathsp = summ / counts;
                for (int m = 0; m < 4; m++)
                {
                    if (m == j)
                        summ2+=0;
                    else
                    {
                        buf = (inputs[i, m] - mathsp);
                        summ2 += Math.Pow(buf, 2);
                    }
                }
            double s2 = summ2 / (counts-1);
            double s = 0.0;
            s = Math.Sqrt(s2);
            double tp = 0.0;
            tp = Math.Abs((time - mathsp) / s);
            if(tp>Student)
            {
                if(perezap==0)
                {
                    q = 0;
                    xx = 0;
                }
                if(q==0)
                {
                    sprobaperezap[countsp] = i;
                     perezap++;
                    label++;
                    CountSproba.Content = $"{label}";
                    countsp++;
                     xx = i;
                    q++;
                }
                else if(q!=0&&xx!=i)
                {
                    sprobaperezap[countsp] = i;
                     perezap++;
                    label++;
                    CountSproba.Content = $"{label}";
                    countsp++;
                    q = 0;
                }
                try
                {
                    using (StreamWriter MyFileG = new StreamWriter("Perev.txt", true, System.Text.Encoding.Default))
                    {
                        MyFileG.WriteLine($"{time}");
                        MyFileG.Close();
                    }
                }
                catch (Exception ex)
                {
                    Inputf.Text = (ex.Message);
                }
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int j = 0;
            for (int i = 0; i < 3; i++)
                Etalone(inputs[i,j],i);
        }
        private void Etalone(double time,int i)
        {
            double summ = 0.0;
            for (int m = 0; m < 4; m++)
               summ += inputs[i, m];
            
            double  msp = summ / 4;
            double summ2 = 0.0;
            for (int m = 0; m < 4; m++)
                summ2 += Math.Pow((inputs[i, m]-msp), 2);
            
            double dp = summ2/3;
            try
            {
                using (StreamWriter MyFileG = new StreamWriter("Data.txt", true, System.Text.Encoding.Default))
                {
                    MyFileG.WriteLine($"{msp} {dp}");
                    MyFileG.Close();
                }
            }
            catch (Exception ex)
            {
                Inputf.Text = (ex.Message);
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)//temporary
        {
            for(int i=0;i<3;i++)
            {
                for(int j=0;j<4;j++)
                {
                    try
                    {
                        using (StreamWriter MyFileG = new StreamWriter("Temporary.txt", true, System.Text.Encoding.Default))
                        {
                            MyFileG.WriteLine($"{inputs[i,j]}");
                            MyFileG.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        Inputf.Text = (ex.Message);
                    }
                }
            }
        }
        static int countsp = 0, q = 0, xx = 0;
    }
}
