using AtendaanceProject.ADOApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace AtendaanceProject.WinApp
{
    /// <summary>
    /// Логика взаимодействия для AddAtendanceWindow.xaml
    /// </summary>
    public partial class AddAtendanceWindow : Window
    {
        public List<Schedule> Schedules { get; set; }
        public AddAtendanceWindow()
        {
            InitializeComponent();
            Schedules = new List<Schedule>(ClassApp.ClassCon.Connection.Schedule);
            this.DataContext = this;
            LoadAtendance();
            LoadStudent();
            LoadSchedule();
        }

        private void btnLeave_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var selectedStudent = CBstudent.SelectedItem as Student;
            var selectedSchedule = CBsubject.SelectedItem as Schedule;
            var selectedAtendance = CBatendance.SelectedItem as AtendanceType;
            var selectedDate = datePanel.SelectedDate;
            Journal newJornal = new Journal
            {
                //id_student = Convert.ToInt32(txtStudent.Text),
                //id_schedule = Convert.ToInt32(txtSubject.Text),
                //id_atendance = Convert.ToInt32(txtAtendance.Text),
                id_student = Convert.ToInt32(selectedStudent.id),
                id_schedule = Convert.ToInt32(selectedSchedule.id),
                id_atendance = Convert.ToInt32(selectedAtendance.id),

                date = Convert.ToDateTime(selectedDate),
                is_delete = false
            };
            ClassApp.ClassCon.Connection.Journal.Add(newJornal);
         
                ClassApp.ClassCon.Connection.SaveChanges();
                MessageBox.Show("добавление прошло успешно", "уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"{ex.Message}", "ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }
        public void LoadStudent()
        {
            CBstudent.ItemsSource = ClassApp.ClassCon.Connection.Student.ToList();
            CBstudent.DisplayMemberPath = "surname";
        }
        public void LoadSchedule()
        {
            CBsubject.ItemsSource = ClassApp.ClassCon.Connection.Schedule.ToList();
            CBsubject.DisplayMemberPath = "id";
        }
        public void LoadAtendance()
        {
            CBatendance.ItemsSource = ClassApp.ClassCon.Connection.AtendanceType.ToList();
            CBatendance.DisplayMemberPath = "title";
        }

    }
}
