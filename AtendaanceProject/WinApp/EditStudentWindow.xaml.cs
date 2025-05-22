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

namespace AtendaanceProject.WinApp
{
    /// <summary>
    /// Логика взаимодействия для EditStudentWindow.xaml
    /// </summary>
    public partial class EditStudentWindow : Window
    {
        public EditStudentWindow()
        {
            InitializeComponent();
            LoadGroup();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var editStudent = new AtendaanceProject.ADOApp.Student();
            var selectedGroup = CBgroup.SelectedItem as Groupi;
            string surname1 = txtStudentSurname.Text;
            string name1 = txtStudentName.Text;
            string patronymic1 = txtStudentPatronymic.Text;
            // крч такой прикол 
            // группа и дата рождения не меняются
            int group1 = selectedGroup.id;
            DateTime date1 = Convert.ToDateTime(datePanel.SelectedDate);
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
        public void LoadGroup()
        {
            CBgroup.ItemsSource = ClassApp.ClassCon.Connection.Groupi.ToList();
            CBgroup.DisplayMemberPath = "title";
        }
    }
}
