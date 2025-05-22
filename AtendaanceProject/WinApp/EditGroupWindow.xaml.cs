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
    /// Логика взаимодействия для EditGroupWindow.xaml
    /// </summary>
    public partial class EditGroupWindow : Window
    {
        public EditGroupWindow()
        {
            InitializeComponent();
            LoadSpeciality();
        }

        private void btnLeave_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var editGroup = new AtendaanceProject.ADOApp.Groupi();
            var selectedSpeciality = CBSpeciality.SelectedItem as Speciality;
            string title1 = txtGroupTitle.Text;
            string course1 = txtGroupCourse.Text;
            // крч такой прикол 
            // группа не меняются
            int speciality1 = selectedSpeciality.id;
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
        public void LoadSpeciality()
        {
            CBSpeciality.ItemsSource = ClassApp.ClassCon.Connection.Speciality.Where(u => u.is_delete != true).ToList();
            CBSpeciality.DisplayMemberPath = "title";
        }
    }
}
