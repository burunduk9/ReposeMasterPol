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
    /// Логика взаимодействия для AdminStudentPage.xaml
    /// </summary>
    public partial class AdminStudentPage : Page
    {
        public List<Student> Students { get; set; }
        public List<Groupi> Groups { get; set; }
        public AdminStudentPage()
        {
            InitializeComponent();
            Students = new List<Student>(ClassApp.ClassCon.Connection.Student);
            Groups = new List<Groupi>(ClassApp.ClassCon.Connection.Groupi.Where(u => u.is_delete != true));
            Groups.Insert(0, new Groupi() { id = -1, title = "all" });
            this.DataContext = this;
        }

        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            var addStudentWindow = new WinApp.AddStudentWindow();
            addStudentWindow.Show();
        }
        private void CBfilterGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedGroup = CBfilterGroup.SelectedItem as Groupi;
            if (selectedGroup.id != -1)
            {
                ListStudents.ItemsSource = Students.Where(u => u.id_group == selectedGroup.id).ToList();
            }
            else
            {
                ListStudents.ItemsSource = Students.ToList();
            }
        }
        private void searchik_TextChanged(object sender, TextChangedEventArgs e)
        {
            string _searchLine = txtsearchik.Text;
            if (_searchLine == "")
            {
                ListStudents.ItemsSource = Students.ToList();
            }
            else
            {
                ListStudents.ItemsSource = Students.Where(u => u.surname.StartsWith(_searchLine, StringComparison.OrdinalIgnoreCase)).ToList();
            }
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var studentEdit = (sender as Button).DataContext as Student;
            var editStudentWindow = new WinApp.EditStudentWindow { DataContext = studentEdit };
            if(editStudentWindow.ShowDialog() == true)
            {
                ListStudents.ItemsSource = new List<Student>(ClassApp.ClassCon.Connection.Student.Where(u => u.is_delete != true).ToList());
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var deleteStudent = (sender as Button).DataContext as Student;
            var deleteStudentMessage = MessageBox.Show($"вы уверены в том, что хотите удалить {deleteStudent.surname} " +
                $"{deleteStudent.name} {deleteStudent.patronymic}?", "подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (deleteStudentMessage == MessageBoxResult.Yes)
            {
                deleteStudent.is_delete = true;
                ClassApp.ClassCon.Connection.SaveChanges();
                ListStudents.ItemsSource = new List<Student>(ClassApp.ClassCon.Connection.Student.Where(u => u.is_delete != true).ToList());
            }
        }
    }
}
