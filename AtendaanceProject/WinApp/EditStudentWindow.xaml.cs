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
using System.Windows.Shapes;
using AtendaanceProject.ADOApp;
using AtendaanceProject.ClassApp;

namespace AtendaanceProject.WinApp
{
    /// <summary>
    /// Логика взаимодействия для EditStudentWindow.xaml
    /// </summary>
    public partial class EditStudentWindow : Window
    {
        public static Student student1 = new Student();
        public static List<Groupi> groups { get; set; }
        public EditStudentWindow(Student studentEdit)
        {
            InitializeComponent();
            groups = new List<Groupi>(ClassApp.ClassCon.Connection.Groupi.Where(u => u.is_delete != true).ToList());
            student1 = studentEdit;
            txtStudentSurname.Text = student1.surname;
            txtStudentName.Text = student1.name;
            txtStudentPatronymic.Text = student1.patronymic;
            CBgroup.SelectedItem = groups.FirstOrDefault(u => u.id == student1.Groupi.id);
            datePanel.SelectedDate = student1.birthday;
            this.DataContext = this;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            student1.surname = txtStudentSurname.Text;
            student1.name = txtStudentName.Text;
            student1.patronymic = txtStudentPatronymic.Text;
            student1.id_group = (CBgroup.SelectedItem as Groupi).id;
            student1.birthday = datePanel.SelectedDate;
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
