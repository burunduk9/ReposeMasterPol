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
    /// Логика взаимодействия для AutoPage.xaml
    /// </summary>
    public partial class AutoPage : Page
    {
        public AutoPage()
        {
            InitializeComponent();
        }

        private void btnAuto_Click(object sender, RoutedEventArgs e)
        {
            var user = ClassApp.ClassCon.Connection.User.Where(u => u.login == txtLog.Text && u.password == txtPas.Password).FirstOrDefault();
            if (txtLog.Text != "" && txtPas.Password != null)
            {
                if (user != null)
                {
                    if (user.id_role == 1)
                    {
                        NavigationService.Navigate(new PageApp.TeacherMainPage());
                        MessageBox.Show($"авторизация прошла успешно, добро пожаловать {user.surname} {user.name} {user.patronymic}");
                    }
                    else
                    {
                        NavigationService.Navigate(new PageApp.AdminMainPage());
                        MessageBox.Show($"авторизация прошла успешно, добро пожаловать {user.surname} {user.name} {user.patronymic}");
                    }
                }
                else
                {
                    MessageBox.Show("такого пользователя нет");
                }
            }
            else
            {
                MessageBox.Show("поля не заполнены");
            }
        }
        private void btnStudent_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageApp.StudentAutoPage());
        }
    }
}
