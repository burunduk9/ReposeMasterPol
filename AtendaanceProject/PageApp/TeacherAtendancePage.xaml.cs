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
        public bool CB1 = false;
        public bool CB2 = false;
        public bool CB3 = false;
        public List<Journal> Atendances { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<Student> Students { get; set; }
        public List<Groupi> Groups { get; set; }
        public TeacherAtendancePage()
        {
            InitializeComponent();
            Atendances = new List<Journal>(ClassApp.ClassCon.Connection.Journal.Where(u => u.is_delete != true));
            Subjects = new List<Subject>(ClassApp.ClassCon.Connection.Subject.Where(u => u.is_delete != true));
            Students = new List<Student>(ClassApp.ClassCon.Connection.Student.Where(u => u.is_delete != true));
            Groups = new List<Groupi>(ClassApp.ClassCon.Connection.Groupi.Where(u => u.is_delete != true));
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
                ListAtendance.ItemsSource = Atendances.Where(u => u.is_delete != true).ToList();
            }
            else
            {
                ListAtendance.ItemsSource = Atendances.Where(u => u.Student.surname.StartsWith(_searchLine, StringComparison.OrdinalIgnoreCase) && u.is_delete != true).ToList();
            }
        }
        private void CBfilterGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CB1 = true; 
            var selectedGroup = CBfilterGroup.SelectedItem as Groupi;
            var selectedStudent = CBfilterStudent.SelectedItem as Student;
            var selectedSubject = CBfilterSubject.SelectedItem as Subject;
            if (selectedGroup.id != -1)
            {
                if(CB2 == true)
                {
                    if (CB3 == true)
                    {
                        ListAtendance.ItemsSource = Atendances.Where(u => u.Schedule.Groupi.id == selectedGroup.id 
                        && u.Student.surname == selectedStudent.surname && u.Schedule.Subject.id == selectedSubject.id 
                        && u.is_delete != true).ToList();
                    }
                    else
                    {
                        ListAtendance.ItemsSource = Atendances.Where(u => u.Schedule.Groupi.id == selectedGroup.id 
                        && u.Student.surname == selectedStudent.surname && u.is_delete != true).ToList();
                    }
                }
                else
                {
                    if(CB3 == true)
                    {
                        ListAtendance.ItemsSource = Atendances.Where(u => u.Schedule.Groupi.id == selectedGroup.id 
                        && u.Schedule.Subject.id == selectedSubject.id && u.is_delete != true).ToList();
                    }
                    else
                    {
                        ListAtendance.ItemsSource = Atendances.Where(u => u.Schedule.Groupi.id == selectedGroup.id 
                        && u.is_delete != true).ToList();
                    }
                }
            }
            else
            {
                ListAtendance.ItemsSource = Atendances.Where(u => u.is_delete != true).ToList();
                CB1 = false;
            }
                //ListAtendance.ItemsSource = Atendances.Where(u => u.Schedule.Groupi.id == selectedGroup.id && u.is_delete != true).ToList();
        }
        private void CBfilterStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CB2 = true;
            var selectedGroup = CBfilterGroup.SelectedItem as Groupi;
            var selectedStudent = CBfilterStudent.SelectedItem as Student;
            var selectedSubject = CBfilterSubject.SelectedItem as Subject;
            if (selectedStudent.id != -1)
            {
                if(CB1 == true)
                {
                    if (CB3 == true)
                    {
                        ListAtendance.ItemsSource = Atendances.Where(u => u.Schedule.Groupi.id == selectedGroup.id 
                        && u.Student.surname == selectedStudent.surname && u.Schedule.Subject.id == selectedSubject.id 
                        && u.is_delete != true).ToList();
                    }
                    else
                    {
                        ListAtendance.ItemsSource = Atendances.Where(u => u.Schedule.Groupi.id == selectedGroup.id 
                        && u.Student.surname == selectedStudent.surname && u.is_delete != true).ToList();
                    }
                }
                else
                {
                    if(CB3 == true)
                    {
                        ListAtendance.ItemsSource = Atendances.Where(u => u.Student.surname == selectedStudent.surname 
                        && u.Schedule.Subject.id == selectedSubject.id && u.is_delete != true).ToList();
                    }
                    else
                    {
                        ListAtendance.ItemsSource = Atendances.Where(u => u.Student.surname == selectedStudent.surname 
                        && u.is_delete != true).ToList();
                    }
                }
            }
            else
            {
                ListAtendance.ItemsSource = Atendances.Where(u => u.is_delete != true).ToList();
                CB2 = false;
            }
            //var selectedStudent = CBfilterStudent.SelectedItem as Student;
            //if (selectedStudent.id != -1)
            //{
            //    ListAtendance.ItemsSource = Atendances.Where(u => u.Student.surname == selectedStudent.surname && u.is_delete != true).ToList();
            //}
            //else
            //{
            //    ListAtendance.ItemsSource = Atendances.Where(u => u.is_delete != true).ToList();
            //}
        }
        private void CBfilterSubject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CB3 = true;
            var selectedGroup = CBfilterGroup.SelectedItem as Groupi;
            var selectedStudent = CBfilterStudent.SelectedItem as Student;
            var selectedSubject = CBfilterSubject.SelectedItem as Subject;
            if (selectedSubject.id != -1)
            {
                if(CB1 == true)
                {
                    if(CB2 == true)
                    {
                        ListAtendance.ItemsSource = Atendances.Where(u => u.Schedule.Groupi.id == selectedGroup.id 
                        && u.Student.surname == selectedStudent.surname && u.Schedule.Subject.id == selectedSubject.id 
                        && u.is_delete != true).ToList();
                    }
                    else
                    {
                        ListAtendance.ItemsSource = Atendances.Where(u => u.Schedule.Groupi.id == selectedGroup.id 
                        && u.Schedule.Subject.id == selectedSubject.id && u.is_delete != true).ToList();
                    }
                }
                else
                {
                    if(CB2 == true)
                    {
                        ListAtendance.ItemsSource = Atendances.Where(u => u.Student.surname == selectedStudent.surname 
                        && u.Schedule.Subject.id == selectedSubject.id && u.is_delete != true).ToList();
                    }
                    else
                    {
                        ListAtendance.ItemsSource = Atendances.Where(u => u.Schedule.Subject.id == selectedSubject.id 
                        && u.is_delete != true).ToList();
                    }
                }
            }
            else
            {
                ListAtendance.ItemsSource = Atendances.Where(u => u.is_delete != true).ToList();
                CB3 = false;
            }
            //var selectedSubject = CBfilterSubject.SelectedItem as Subject;
            //if (selectedSubject.id != -1)
            //{
            //    ListAtendance.ItemsSource = Atendances.Where(u => u.Schedule.Subject.id == selectedSubject.id && u.is_delete != true ).ToList();
            //}
            //else
            //{
            //    ListAtendance.ItemsSource = Atendances.Where(u => u.is_delete != true).ToList();
            //}
        }
        private void btnAddAtendance_Click(object sender, RoutedEventArgs e)
        {
            var addAtendanceWindow = new WinApp.AddAtendanceWindow();
            addAtendanceWindow.Show();
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var atendanceEdit = (sender as Button).DataContext as Journal;
            WinApp.EditAtendanceWindow editAtendance = new WinApp.EditAtendanceWindow(atendanceEdit);
            editAtendance.Show();
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
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            Atendances = new List<Journal>(ClassApp.ClassCon.Connection.Journal.Where(u => u.is_delete != true));
        }
    }
}
