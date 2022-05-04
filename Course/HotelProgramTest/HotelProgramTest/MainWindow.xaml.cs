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

namespace HotelProgramTest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.WindowStartupLocation=System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void GuestButton_Click(object sender, RoutedEventArgs e)
        {
            ZvitClients ww;
            ww=new ZvitClients();
            Hide();
            ww.Show();
        }

        private void EmplyButton_Click(object sender, RoutedEventArgs e)
        {
            GetInformation ww;
            ww=new GetInformation();
            Hide();
            ww.Show();
        }

        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            AdminPage ww;
            ww=new AdminPage();
            Hide();
            ww.Show();
        }
    }
}
