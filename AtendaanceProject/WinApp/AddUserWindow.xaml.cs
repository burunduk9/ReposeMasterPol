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
using AtendaanceProject.ADOApp;

namespace AtendaanceProject.WinApp
{
    /// <summary>
    /// Логика взаимодействия для AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public AddUserWindow()
        {
            InitializeComponent();
            LoadRole();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtSurname.Text == "" || txtName.Text == "" || txtPatronymic.Text == "" || txtLogin.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("заполните поля");
                return;
            }
            var selectedRole = CBrole.SelectedItem as Role;
            var newUser = new User
            {
                surname = txtSurname.Text,
                name = txtName.Text,
                patronymic = txtPatronymic.Text,
                id_role = selectedRole.id,
                login = txtLogin.Text,
                password = txtPassword.Text,
                is_delete = false
            };
            ClassApp.ClassCon.Connection.User.Add(newUser);
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
        public void LoadRole()
        {
            CBrole.ItemsSource = ClassApp.ClassCon.Connection.Role.ToList();
            CBrole.DisplayMemberPath = "title";
        }
    }
}
