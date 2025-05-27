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
    /// Логика взаимодействия для TeacherMainPage.xaml
    /// </summary>
    public partial class TeacherMainPage : Page
    {
        public TeacherMainPage()
        {
            InitializeComponent();
        }

        private void btnShowAtendanceList_Click(object sender, RoutedEventArgs e)
        {
            MainFrameTeacher.NavigationService.Navigate(new PageApp.TeacherAtendancePage());
        }
        private void btnLeave_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageApp.AutoPage());
        }
        private void btnShowStudentList_Click(object sender, RoutedEventArgs e)
        {
            MainFrameTeacher.NavigationService.Navigate(new PageApp.TeacherStudentPage());
        }
    }
}
