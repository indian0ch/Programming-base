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
    /// Логика взаимодействия для Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
         Label label,label2,label1;
        Grid myGrid;
         Button Btn;
        Image img;
        public Window4()
        {
            InitializeComponent();
            initControls();    
        }
        private void initControls()
        {
            this.Title = "Information|Window4";
            this.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA7E8E0"));
            this.ResizeMode = ResizeMode.NoResize;
            myGrid = new Grid();
            myGrid.Width = Window1.Width;
            myGrid.Height = Window1.Height;
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;
            Images();
            Buttons();
            Labels();
            myGrid.Children.Add(img);
            Window1.Content = myGrid;
            Window1.Show();
        }
        private void Images()
        {
            img = new Image();
            img.Source = new BitmapImage(new Uri(@"\\Mac\Home\Desktop\IMG_3612.jpg"));
            img.Width = 170;
            img.Height = 170;
            img.Margin = new Thickness(0, 164, 10, 0);
            img.HorizontalAlignment = HorizontalAlignment.Right;
            img.VerticalAlignment = VerticalAlignment.Top;
        }
        private void Buttons()
        {
            Btn = new Button();
            Btn.Content = "Back To Main";
            Btn.Width = 130;
            Btn.Height = 45;
            Btn.Foreground = Brushes.White;
            Btn.Background = Brushes.Red;
            Btn.HorizontalAlignment = HorizontalAlignment.Right;
            Btn.Margin = new Thickness(0, 340, 30, 0);
            Btn.Click += Btn_Click;
            myGrid.Children.Add(Btn);
        }
        private void Labels()
        {
            label = new Label();
            label1 = new Label();
            label2 = new Label();
            Label[] lbls = new Label[] { label, label1,label2 };
            label1.Content = "Andrii Fesiuk KP-12 2022";
            label.Content = "Some Information about Us";
            label2.Content = "Faculty OF Applied Math";
            for (int i=0;i<lbls.Length;i++)
            {
                lbls[i].FontSize = 14;
                lbls[i].FontFamily = new FontFamily("Cambria");
                lbls[i].Height = 45;
                lbls[i].Foreground = Brushes.White;
                lbls[i].Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF92A8BF"));
            }
            label.Margin = new Thickness(0, 10, 0, 0);
            label1.Margin = new Thickness(40, 145, 0, 0);
            label2.Margin = new Thickness(0, 121, 30, 0);
            label2.Width = 185;
            label.Width = 350;
            label.FontSize = 29;
            label.Background = Brushes.DarkRed;
            label.VerticalAlignment = VerticalAlignment.Top;
            label2.VerticalAlignment = VerticalAlignment.Top;
            label1.HorizontalAlignment = HorizontalAlignment.Left;
            for (int i = 0; i < lbls.Length; i++)
                myGrid.Children.Add(lbls[i]);
        }
        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw;
            mw = new MainWindow();
            Hide();
            mw.Show();
        }
    }
}
