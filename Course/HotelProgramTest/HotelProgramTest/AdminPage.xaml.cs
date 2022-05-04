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

namespace HotelProgramTest
{
    /// <summary>
    /// Логика взаимодействия для AdminPag.xaml
    /// </summary>
    public partial class AdminPag : Window
    {
        public AdminPag()
        {
            InitializeComponent();
        }
        /*
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
        */
        private void AccDelWorkers_Click(object sender, RoutedEventArgs e)
        {
            AcceptWorkersOnWork ww=new AcceptWorkersOnWork();
            Hide();
            ww.Show();
        }

        private void ChangeSchedule_Click(object sender, RoutedEventArgs e)
        {
            ChangeScheduleWorkers ww = new ChangeScheduleWorkers();
            Hide();
            ww.Show();
        }

        private void EditClients_Click(object sender, RoutedEventArgs e)
        {
            PoselVuselClients ww;
            ww = new PoselVuselClients();
            Hide();
            ww.Show();
        }

        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminPage ww;
            ww = new AdminPage();
            Hide();
            ww.Show();
        }

        private void MakeZvitBtn_Click(object sender, RoutedEventArgs e)
        {
            ZvitAdmin ww;
            ww=new ZvitAdmin();
            Hide();
            ww.Show();
        }
    }
}
