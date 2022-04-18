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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prac3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Title = "Main Window| Andriy Fesiuk Kp-12";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserWindow ww;
            ww=new UserWindow();
            Hide();
            ww.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AboutUs ww;
            ww=new AboutUs();
            Hide();
            ww.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Admino ww;
            ww=new Admino();
            Hide();
            ww.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
