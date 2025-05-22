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
using System.Windows.Shapes;
using AtendaanceProject.ClassApp;

namespace AtendaanceProject.WinApp
{
    /// <summary>
    /// Логика взаимодействия для AddStudentWindow.xaml
    /// </summary>
    public partial class AddStudentWindow : Window
    {
        public AddStudentWindow()
        {
            InitializeComponent();
            LoadGroup();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtSurname.Text == "" || txtName.Text == "" || txtPatronymic.Text == "")
            {
                MessageBox.Show("заполните поля");
                return;
            }
            var selectedGroup = CBgroup.SelectedItem as Groupi;
            var newStudent = new Student
            {
                surname = txtSurname.Text,
                name = txtName.Text,
                patronymic = txtPatronymic.Text,
                id_group = selectedGroup.id,
                birthday = datePanel.SelectedDate,
                is_delete = false
            };
            ClassApp.ClassCon.Connection.Student.Add(newStudent);
            try
            {
                ClassApp.ClassCon.Connection.SaveChanges();
                MessageBox.Show("добавление прошло успешно", "уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
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
        public void LoadGroup()
        {
            CBgroup.ItemsSource = ClassApp.ClassCon.Connection.Groupi.ToList();
            CBgroup.DisplayMemberPath = "title";
        }
    }
}
