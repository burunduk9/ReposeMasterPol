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

namespace AtendaanceProject.WinApp
{
    /// <summary>
    /// Логика взаимодействия для EditAtendanceWindow.xaml
    /// </summary>
    public partial class EditAtendanceWindow : Window
    {
        public static Journal jornal1 = new Journal();
        public static List<Student> students { get; set; }
        public static List<Schedule> schedules { get; set; }
        public static List<AtendanceType> atendances { get; set; }
        public EditAtendanceWindow(Journal atendanceEdit)
        {
            InitializeComponent();
            students= new List<Student>(ClassApp.ClassCon.Connection.Student.Where(u => u.is_delete != true).ToList());
            schedules= new List<Schedule>(ClassApp.ClassCon.Connection.Schedule.ToList());
            atendances= new List<AtendanceType>(ClassApp.ClassCon.Connection.AtendanceType.ToList());
            jornal1 = atendanceEdit;
            txtBirthday.Text = Convert.ToString(jornal1.date);
            CBstudents.SelectedItem = students.FirstOrDefault(u => u.id == jornal1.Student.id);
            CBschedule.SelectedItem = schedules.FirstOrDefault(u => u.id == jornal1.Schedule.id);
            CBatendance.SelectedItem = atendances.FirstOrDefault(u => u.id == jornal1.AtendanceType.id);
            datePanel.SelectedDate = jornal1.date;
            this.DataContext = this;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            jornal1.id_student = (CBstudents.SelectedItem as Student).id;
            jornal1.id_schedule = (CBschedule.SelectedItem as Schedule).id;
            jornal1.id_atendance = (CBatendance.SelectedItem as AtendanceType).id;
            jornal1.date = datePanel.SelectedDate;
            try
            {
                ClassApp.ClassCon.Connection.SaveChanges();
                MessageBox.Show("данные были успешно обновлены", "уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnLeave_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
