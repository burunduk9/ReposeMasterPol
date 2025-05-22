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
    /// Логика взаимодействия для AddGroupWindow.xaml
    /// </summary>
    public partial class AddGroupWindow : Window
    {
        public AddGroupWindow()
        {
            InitializeComponent();
            LoadSpeciality();
        }

        private void btnLeave_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = this;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtTitle.Text == "" || txtCourse.Text == "")
            {
                MessageBox.Show("заполните поля");
                return;
            }
            var selectedSpeciality = CBSpeciality.SelectedItem as Speciality;
            var newGroup = new Groupi
            {
                title = txtTitle.Text,
                course = Convert.ToInt32(txtCourse.Text),
                id_speciality = Convert.ToInt32(selectedSpeciality.id),
                is_delete = false
            };
            ClassApp.ClassCon.Connection.Groupi.Add(newGroup);
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
        public void LoadSpeciality()
        {
            CBSpeciality.ItemsSource = ClassApp.ClassCon.Connection.Speciality.ToList();
            CBSpeciality.DisplayMemberPath = "title";
        }
    }
}
