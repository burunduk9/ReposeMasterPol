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
using AtendaanceProject.ADOApp;

namespace AtendaanceProject.PageApp
{
    /// <summary>
    /// Логика взаимодействия для StudentMainPage.xaml
    /// </summary>
    public partial class StudentMainPage : Page
    {
        Student student1 = new Student();
        public StudentMainPage(Student student)
        {
            InitializeComponent();
            student1 = student;
            this.DataContext = this;
        }

        private void btnShowAtendance_Click(object sender, RoutedEventArgs e)
        {
            MainFrameStudent.NavigationService.Navigate(new PageApp.StudentAtendancePage(student1));
        }
        private void btnShowSchedule_Click(object sender, RoutedEventArgs e)
        {
            MainFrameStudent.NavigationService.Navigate(new PageApp.StudentSchedulePage(student1));
        }
        private void btnLeave_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageApp.AutoPage());
        }
    }
}
