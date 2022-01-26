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

namespace Lab2
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Grid myGrid;
        static StreamWriter MyFileG;
        static StreamReader DataFile;
        public Window1()
        {
            InitializeComponent();
            initControls();
        }
        private void initControls()
        {
            this.Title = "Base Of Student|Window1";
            //this.ResizeMode = ResizeMode.NoResize;
            this.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA7E8E0"));
            myGrid = new Grid();
            myGrid.Width = this.Width;
            myGrid.Height = this.Height;
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;
            myGrid.ShowGridLines = true;
            Labels();
            Buttons();
            TextBoxes();
            this.Content = myGrid; // this.Content = myGrid;
            this.Show();
        }
        private void Labels()
        {
            Label lbl1 = new Label();
            Label lbl2 = new Label();
            Label lbl3 = new Label();
            Label lbl4 = new Label();
            Label lbl5 = new Label();
            Label lbl6 = new Label();
            Label[] lbls = new Label[] { lbl1, lbl2, lbl3, lbl4, lbl5, lbl6 };
            lbl1.Content = "First Window Of Our Program";
            lbl2.Content = "Введіть ID залікової книжки студента";
            lbl3.Content = "Введіть Прізвище";
            lbl4.Content = "Введіть ім'я";
            lbl5.Content = "Введіть номер групи студента";
            lbl6.Content = "Введіть номер залікової книжки студента,якого потрібно видалити";
            for(int i=0;i<lbls.Length;i++ )
            {
                lbls[i].Height = 23;
                lbls[i].Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3E2AD0"));
                lbls[i].Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF9F9F9"));
                lbls[i].FontSize = 12;
                lbls[i].FontFamily = new FontFamily("Sitka Small");
                lbls[i].Width = 299;
                if (lbls[i]!=lbl6||lbls[i]!=lbl1)
                {
                    lbls[i].VerticalAlignment = VerticalAlignment.Top;
                    lbls[i].HorizontalAlignment = HorizontalAlignment.Left;
                }
            }
            lbl1.Margin= new Thickness(0, 22, 0, 0);
            lbl1.VerticalAlignment = VerticalAlignment.Top;
            lbl1.HorizontalAlignment = HorizontalAlignment.Center;
            lbl1.FontSize = 24;
            lbl1.Height = 43;
            lbl1.Width = 380;
            lbl2.Margin = new Thickness(0, 72, 0, 0);
            lbl3.Margin = new Thickness(0, 147, 0, 0);
            lbl4.Margin = new Thickness(0, 222, 0, 0);
            lbl5.Margin = new Thickness(0, 303, 0, 0);
            lbl6.Margin = new Thickness(369, 136, 0, 0);
            lbl6.Width = 450;
            for (int i = 0; i < lbls.Length; i++)
                myGrid.Children.Add(lbls[i]);
        }
        private void Buttons()
        {
            Button btn1 = new Button();
            Button btn2 = new Button();
            Button btn3 = new Button();
            btn1.Content = "Записати до файлу";
            btn2.Content = "Видалити";
            btn3.Content = "Back To Main";
            Button[] btns = new Button[] { btn1, btn2, btn3 };
            for(int i=0;i<btns.Length;i++)
            {
                btns[i].Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF9F9F9"));
                btns[i].Background = Brushes.Black;
                btns[i].Height = 45;
                btns[i].VerticalAlignment = VerticalAlignment.Top;
                btns[i].FontSize = 12;
                btns[i].FontFamily= new FontFamily("Sitka Small");
            }
            btn3.Background = Brushes.Red;
            btn1.Width =180;
            btn2.Width =113;
            btn3.Width =113;
            btn1.Margin = new Thickness(124,309,0,0);
            btn2.Margin = new Thickness(525, 235, 0, 0);
            btn3.Margin = new Thickness(635, 376, 0, 0);
            btn1.Click += Button_Click;
            btn2.Click += Button_Click_1;
            btn3.Click += Button1W_Click;
            for (int i = 0; i < btns.Length; i++)
                myGrid.Children.Add(btns[i]);
        }
        TextBox Surname=new TextBox();
        TextBox Number = new TextBox();
        TextBox Group = new TextBox();
        TextBox Numdel = new TextBox();
        TextBox Name = new TextBox();
        private void TextBoxes()
        {
            TextBox[] txts = new TextBox[] { Surname, Name, Group,Number, Numdel };
            for (int i = 0;i<txts.Length;i++)
            {
                txts[i].Width = 150;
                txts[i].Height = 45;
                txts[i].FontSize = 14;
                txts[i].VerticalAlignment = VerticalAlignment.Top;
                if (txts[i] != Numdel)
                {
                    txts[i].HorizontalAlignment = HorizontalAlignment.Left;
                }
            }
            Number.Margin = new Thickness(20, 97, 0, 0);
            Surname.Margin = new Thickness(20, 172, 0, 0);
            Name.Margin = new Thickness(20, 246, 0, 0);
            Group.Margin = new Thickness(20, 328, 0, 0);
            Numdel.Margin = new Thickness(524, 167, 0, 0);
            Numdel.VerticalAlignment = VerticalAlignment.Top;
            for (int i = 0; i < txts.Length; i++)
                myGrid.Children.Add(txts[i]);
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

        private void Window0_SizeChanged(object sender, SizeChangedEventArgs e)
        {/*
            double val = Math.Max(1.0 *830 / this.Width, 1.0 * 450 / this.Height);
            //lbl.FontSize = (int)(1.0 * 46 / val);
            myGrid.Width = (int)(1.0 * 830 / val);
            myGrid.Height = (int)(1.0 * 450 / val);
        */
        }
    }
}
