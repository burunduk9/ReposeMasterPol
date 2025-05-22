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
    /// Логика взаимодействия для TeacherAtendancePage.xaml
    /// </summary>
    public partial class TeacherAtendancePage : Page
    {
        public List<Journal> Atendances { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<Student> Students { get; set; }
        public List<Groupi> Groups { get; set; }
        public TeacherAtendancePage()
        {
            InitializeComponent();
            Atendances = new List<Journal>(ClassApp.ClassCon.Connection.Journal);
            Subjects = new List<Subject>(ClassApp.ClassCon.Connection.Subject);
            Students = new List<Student>(ClassApp.ClassCon.Connection.Student);
            Groups = new List<Groupi>(ClassApp.ClassCon.Connection.Groupi);
            Subjects.Insert(0, new Subject() { id = -1, title = "all" });
            Students.Insert(0, new Student() { id = -1, surname = "all" });
            Groups.Insert(0, new Groupi() { id = -1, title = "all" });
            this.DataContext = this;
        }

        private void txtsearchik_TextChanged(object sender, TextChangedEventArgs e)
        {
            string _searchLine = txtsearchik.Text;
            if (_searchLine == "")
            {
                ListAtendance.ItemsSource = Atendances.ToList();
            }
            else
            {
                ListAtendance.ItemsSource = Atendances.Where(u => u.Student.surname.StartsWith(_searchLine, StringComparison.OrdinalIgnoreCase)).ToList();
            }
        }
        private void CBfilterGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedGroup = CBfilterGroup.SelectedItem as Groupi;
            if (selectedGroup.id != -1)
            {
                ListAtendance.ItemsSource = Atendances.Where(u => u.Schedule.Groupi.id == selectedGroup.id).ToList();
            }
            else
            {
                ListAtendance.ItemsSource = Atendances.ToList();
            }
        }
        private void CBfilterStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedStudent = CBfilterStudent.SelectedItem as Student;
            if (selectedStudent.id != -1)
            {
                ListAtendance.ItemsSource = Atendances.Where(u => u.Student.surname == selectedStudent.surname).ToList();
            }
            else
            {
                ListAtendance.ItemsSource = Atendances.ToList();
            }
        }
        private void CBfilterSubject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedSubject = CBfilterSubject.SelectedItem as Subject;
            if (selectedSubject.id != -1)
            {
                ListAtendance.ItemsSource = Atendances.Where(u => u.Schedule.Subject.id == selectedSubject.id).ToList();
            }
            else
            {
                ListAtendance.ItemsSource = Atendances.ToList();
            }
        }
        private void btnAddAtendance_Click(object sender, RoutedEventArgs e)
        {
            var addAtendanceWindow = new WinApp.AddAtendanceWindow();
            addAtendanceWindow.Show();
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var atendanceEdit = (sender as Button).DataContext as Journal;
            var editAtendanceWindow = new WinApp.EditAtendanceWindow { DataContext = atendanceEdit };
            if (editAtendanceWindow.ShowDialog() == true)
            {
                ListAtendance.ItemsSource = new List<Journal>(ClassApp.ClassCon.Connection.Journal.Where(u => u.is_delete != true).ToList());
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var deleteAtendance = (sender as Button).DataContext as Journal;
            var deleteAtendanceMessage = MessageBox.Show($"вы уверены в том, что хотите удалить {deleteAtendance.Student.surname} " +
                $"{deleteAtendance.Student.name} {deleteAtendance.Student.patronymic}?", "подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (deleteAtendanceMessage == MessageBoxResult.Yes)
            {
                deleteAtendance.is_delete = true;
                ClassApp.ClassCon.Connection.SaveChanges();
                ListAtendance.ItemsSource = new List<Journal>(ClassApp.ClassCon.Connection.Journal.Where(u => u.is_delete != true).ToList());
            }
        }
        private void datePanel_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var _selectedDateToSearch = (sender as DatePicker).SelectedDate;
            if (_selectedDateToSearch != null)
            {
                ListAtendance.ItemsSource = Atendances.Where(u => u.date == _selectedDateToSearch).ToList();
            }
        }
    }
}
