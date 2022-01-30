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
using System.IO;

namespace Lab1
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        static StreamWriter MyFileG;
        static StreamReader DataFile;
        public Window1()
        {
            InitializeComponent();
        }
        private void Button1W_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw;
            mw = new MainWindow();
            Hide();
            mw.Show();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Number.Text == "" || Surname.Text == "" || Name.Text == "" || Group.Text == "")
            {
                if (Number.Text == "")
                    Number.Text = "Write ID";
                else if (Surname.Text == "")
                    Surname.Text = "Write Surname";
                else if (Name.Text == "")
                    Name.Text = "Write Name";
                else if (Group.Text == "")
                    Group.Text = "Write Group";
            }
            else
            {
                string informstud;
                informstud = " " + Number.Text + " " + Surname.Text + " " + Name.Text + " " + Group.Text + " ";
                //реалізовано з дозаписом файлу
                try
                {
                    using (StreamWriter MyFileG = new StreamWriter("G.txt", true, System.Text.Encoding.Default))
                    {
                        MyFileG.WriteLine($"{informstud}");
                        MyFileG.Close();
                    }
                }
                catch (Exception ex)
                {
                    Number.Text = (ex.Message);
                }
                Number.Text = "";
                Surname.Text = "";
                Name.Text = "";
                Group.Text = "";
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Numdel.Text == "")
            {
                Numdel.Text = "Write number ID";
            }
            else 
            {
                try
                {
                    DataFile = new StreamReader("G.txt");
                }
                catch (Exception ex)
                {
                    Numdel.Text = (ex.Message);
                    return;
                }
                int buf = 0;// колво слов 
                string[] Line;
                Line = DataFile.ReadToEnd().Split(' ');//зчитування
                buf = Line.Length;
                DataFile.Close();
                for (int i = 0; i < Line.Length; i++)
                {
                    if (Line[i] == Numdel.Text)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            Line[i + j] = "-";
                        }
                        i += 3;
                    }
                }
                File.WriteAllText("G.txt", null);
                MyFileG = new StreamWriter("G.txt");
                for (int i = 0; i < Line.Length; i++)
                {
                    if (Line[i] != "-")
                    {
                        MyFileG.Write($"{Line[i]}");
                        MyFileG.Write(" ");
                    }
                    else
                    {
                        MyFileG.Write("_");
                        MyFileG.Write(" ");
                    }
                }
                MyFileG.Close();
                Numdel.Text = "";
            }
        }  
    }
}
