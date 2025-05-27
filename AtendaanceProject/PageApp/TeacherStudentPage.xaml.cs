using AtendaanceProject.ADOApp;
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
    /// Логика взаимодействия для TeacherStudentPage.xaml
    /// </summary>
    public partial class TeacherStudentPage : Page
    {
        public List<Student> Students { get; set; }
        public List<Groupi> Groups { get; set; }
        public TeacherStudentPage()
        {
            InitializeComponent();
            Students = new List<Student>(ClassApp.ClassCon.Connection.Student.Where(u => u.is_delete != true));
            Groups = new List<Groupi>(ClassApp.ClassCon.Connection.Groupi.Where(u => u.is_delete != true));
            Groups.Insert(0, new Groupi() { id = -1, title = "all" });
            this.DataContext = this;
        }

        private void CBfilterGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedGroup = CBfilterGroup.SelectedItem as Groupi;
            if(selectedGroup.id != -1)
            {
                ListStudent.ItemsSource = Students.Where(u => u.Groupi.id == selectedGroup.id && u.is_delete != true).ToList();
            }
            else
            {
                ListStudent.ItemsSource = Students.Where(u => u.is_delete != true).ToList();
            }
        }
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            Students = new List<Student>(ClassApp.ClassCon.Connection.Student.Where(u => u.is_delete != true));
        }
        private void txtsearchik_TextChanged(object sender, TextChangedEventArgs e)
        {
            string _searchLine = txtsearchik.Text;
            if (_searchLine == "")
            {
                ListStudent.ItemsSource = Students.Where(u => u.is_delete != true).ToList();
            }
            else
            {
                ListStudent.ItemsSource = Students.Where(u => u.surname.StartsWith(_searchLine, StringComparison.OrdinalIgnoreCase) && u.is_delete != true).ToList();
            }
        }
    }
}
