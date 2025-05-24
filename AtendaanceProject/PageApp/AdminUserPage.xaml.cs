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
using System.Windows.Navigation;
using System.Windows.Shapes;
using AtendaanceProject.ADOApp;

namespace AtendaanceProject.PageApp
{
    /// <summary>
    /// Логика взаимодействия для AdminUserPage.xaml
    /// </summary>
    public partial class AdminUserPage : Page
    {
        public List<User> Users { get; set; }
        public List<Role> Roles { get; set; }
        public AdminUserPage()
        {
            InitializeComponent();
            Users = new List<User>(ClassApp.ClassCon.Connection.User.Where(u => u.is_delete != true));
            Roles = new List<Role>(ClassApp.ClassCon.Connection.Role);
            Roles.Insert(0, new Role() { id = -1, title = "all" });
            this.DataContext = this;
        }

        private void CBfilterRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedRole = CBfilterRole.SelectedItem as Role;
            if (selectedRole.id != -1)
            {
                ListUser.ItemsSource = Users.Where(u => u.id_role == selectedRole.id && u.is_delete != true).ToList();
            }
            else
            {
                ListUser.ItemsSource = Users.Where(u => u.is_delete != true).ToList();
            }
        }
        private void txtsearchik_TextChanged(object sender, TextChangedEventArgs e)
        {
            string _searchLine = txtsearchik.Text;
            if (_searchLine == "")
            {
                ListUser.ItemsSource = Users.Where(u => u.is_delete != true).ToList();
            }
            else
            {
                ListUser.ItemsSource = Users.Where(u => u.surname.StartsWith(_searchLine, StringComparison.OrdinalIgnoreCase) && u.is_delete != true).ToList();
            }
        }
        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            WinApp.AddUserWindow addUser = new WinApp.AddUserWindow();
            addUser.Show();
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var userEdit = (sender as Button).DataContext as User;
            WinApp.EditUserWindow editUser = new WinApp.EditUserWindow(userEdit);
            editUser.Show();
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var deleteUser = (sender as Button).DataContext as User;
            var deleteUserMessage = MessageBox.Show($"вы уверены в том, что хотите удалить {deleteUser.surname} " +
                $"{deleteUser.name} {deleteUser.patronymic}?", "подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (deleteUserMessage == MessageBoxResult.Yes)
            {
                deleteUser.is_delete = true;
                ClassApp.ClassCon.Connection.SaveChanges();
                ListUser.ItemsSource = new List<User>(ClassApp.ClassCon.Connection.User.Where(u => u.is_delete != true).ToList());
            }
        }
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            Users = new List<User>(ClassApp.ClassCon.Connection.User.Where(u => u.is_delete != true));
        }
    }
}
