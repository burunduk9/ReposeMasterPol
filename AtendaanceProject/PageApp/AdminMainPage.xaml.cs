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

namespace AtendaanceProject.PageApp
{
    /// <summary>
    /// Логика взаимодействия для AdminMainPage.xaml
    /// </summary>
    public partial class AdminMainPage : Page
    {
        public AdminMainPage()
        {
            InitializeComponent();
        }

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            MainFrameAdmin.NavigationService.Navigate(new PageApp.AdminUserPage());
        }
        private void btnStudent_Click(object sender, RoutedEventArgs e)
        {
            MainFrameAdmin.NavigationService.Navigate(new PageApp.AdminStudentPage());
        }
        private void btnSpeciality_Click(object sender, RoutedEventArgs e)
        {
            MainFrameAdmin.NavigationService.Navigate(new PageApp.AdminSpecialityPage());
        }
        private void btnGroup_Click(object sender, RoutedEventArgs e)
        {
            MainFrameAdmin.NavigationService.Navigate(new PageApp.AdminGroupPage());
        }

        private void btnSubject_Click(object sender, RoutedEventArgs e)
        {
            MainFrameAdmin.NavigationService.Navigate(new PageApp.AdminSubjectPage());
        }

        private void btnOtchet_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
