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
using System.Xml.Linq;

namespace AtendaanceProject.WinApp
{
    /// <summary>
    /// Логика взаимодействия для AddSpecialityWindow.xaml
    /// </summary>
    public partial class AddSpecialityWindow : Window
    {
        public AddSpecialityWindow()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtTitle.Text == "")
            {
                MessageBox.Show("заполните поля");
                return;
            }
            var newSpeciality = new Speciality
            {
                title = txtTitle.Text,
                description = txtDescription.Text,
                is_delete = false
            };
            ClassApp.ClassCon.Connection.Speciality.Add(newSpeciality);
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
            this.DataContext = this;
        }
    }
}
