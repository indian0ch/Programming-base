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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        static int M = 6;
        Button Btn;
        Label label;
        Grid myGrid;
        public Window2()
        {
            InitializeComponent();
            initControls();
        }
        private void initControls()
        {
            this.Title = "Хрестики-нолики|Window2";
           // this.ResizeMode = ResizeMode.NoResize;
            myGrid = new Grid();
            myGrid.Width = Window1.Width;
            myGrid.Height = Window1.Height;
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;
            myGrid.ShowGridLines = false;
            ComboBox[,] ArrCmb = new ComboBox[M, M];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    string[] mas = { "X", "O" };
                    ArrCmb[i, j] = new ComboBox();
                    ArrCmb[i, j].Items.Add("X");
                    ArrCmb[i, j].Items.Add("O");
                    ArrCmb[i, j].FontSize = 25;
                    ArrCmb[i, j].FontFamily = new FontFamily("Cambria Math");
                }
            }
            RowDefinition[] rows = new RowDefinition[M];
            ColumnDefinition[] cols = new ColumnDefinition[M];
            for (int i = 0; i < 6; i++)
            {
                rows[i] = new RowDefinition();
                myGrid.RowDefinitions.Add(rows[i]);
                cols[i] = new ColumnDefinition();
                myGrid.ColumnDefinitions.Add(cols[i]);
            }
            myGrid.Background = Brushes.LightCoral;
            Labels();
            Buttons();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                        Grid.SetRow(ArrCmb[i, j], i+1);
                        Grid.SetColumn(ArrCmb[i, j], j);
                }
            }
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    myGrid.Children.Add(ArrCmb[i, j]);
            Window1.Content = myGrid;
            Window1.Show();
        }
        private void Labels()
        {
            label = new Label();
            label.Content = "Хрестики - Нолики";
            label.FontSize = 30;
            label.HorizontalAlignment = HorizontalAlignment.Center;
            label.VerticalAlignment = VerticalAlignment.Center;
            label.FontFamily = new FontFamily("Cambria");
            label.Background = Brushes.LightCoral;
            Grid.SetColumnSpan(label, 6);
            Grid.SetRow(label, 0);
            myGrid.Children.Add(label);
        }
        private void Buttons()
        {
            Btn = new Button();
            Btn.Width = 130;
            Btn.Height = 45;
            Btn.Content = "Back To Main";
            Btn.Background = Brushes.OrangeRed;
            Btn.HorizontalAlignment = HorizontalAlignment.Center;
            Btn.VerticalAlignment = VerticalAlignment.Center;
            Btn.Click += Btn_Click;
            Grid.SetRow(Btn, 5);
            Grid.SetColumn(Btn, 5);
            myGrid.Children.Add(Btn);
        }
        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow wm = new MainWindow();
            Hide();
            wm.Show();
        }
        private void Window1_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double val = Math.Max(1.0 * 800 / this.Width,1.0 * 450 / this.Height);
            label.FontSize = (int)(1.0 * 30 / val);
            myGrid.Width = (int)(1.0 * 800 / val);
            myGrid.Height = (int)(1.0 * 450 / val);
            Btn.Width = (int)(1.0 * 130 / val);
            Btn.Height = (int)(1.0 * 45 / val);
        }
    }
}
