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
    /// Логика взаимодействия для StudentSchedulePage.xaml
    /// </summary>
    public partial class StudentSchedulePage : Page
    {
        public List<Journal> Atendances { get; set; }
        Student student2 = new Student();
        public StudentSchedulePage(Student student1)
        {
            InitializeComponent();
            txtSurName.Content = student2.surname;
            txtName.Content = student2.name;
            txtPatronymic.Content = student2.patronymic;

            student2 = student1;
            Atendances = new List<Journal>(ClassApp.ClassCon.Connection.Journal.Where(u => u.id_student == student2.id && u.is_delete != true));
            this.DataContext = this;
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            Atendances = new List<Journal>(ClassApp.ClassCon.Connection.Journal.Where(u => u.id_student == student2.id && u.is_delete != true));
        }
        private void dateSearch_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var _selectedDateToSearch = (sender as DatePicker).SelectedDate;
            if (_selectedDateToSearch != null)
            {
                ListStudent.ItemsSource = Atendances.Where(u => u.date == _selectedDateToSearch && u.id_student == student2.id && u.is_delete != true).ToList();
            }
        }
    }
}
