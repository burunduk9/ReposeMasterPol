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
    /// Логика взаимодействия для EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
        public static User user1 = new User();
        public static List<Role> Roles { get; set; }
        public EditUserWindow(User userEdit)
        {
            InitializeComponent();
            Roles = new List<Role>(ClassApp.ClassCon.Connection.Role.ToList());
            user1 = userEdit;
            txtUserSurname.Text = user1.surname;
            txtUserName.Text = user1.name;
            txtUserPatronymic.Text = user1.patronymic;
            txtLogin.Text = user1.login;
            txtPassword.Text = user1.password;
            CBrole.SelectedItem = Roles.FirstOrDefault(u => u.id == user1.Role.id);
            this.DataContext = this;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            user1.surname = txtUserSurname.Text;
            user1.name = txtUserName.Text;
            user1.patronymic = txtUserPatronymic.Text;
            user1.id_role = (CBrole.SelectedItem as Role).id;
            user1.login = txtLogin.Text;
            user1.password = txtPassword.Text;
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
