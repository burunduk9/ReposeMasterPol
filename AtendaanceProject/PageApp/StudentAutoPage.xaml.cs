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
    /// Логика взаимодействия для StudentAutoPage.xaml
    /// </summary>
    public partial class StudentAutoPage : Page
    {
        public StudentAutoPage()
        {
            InitializeComponent();
        }

        private void btnAuto_Click(object sender, RoutedEventArgs e)
        {
            var student = ClassApp.ClassCon.Connection.Student.Where(u => u.surname == txtSurname.Text && u.name == txtName.Text && u.patronymic == txtPatronymic.Text).FirstOrDefault();
            if (txtSurname.Text != "" && txtName.Text != "" && txtPatronymic.Text != "")
            {
                if (student != null)
                {
                    NavigationService.Navigate(new PageApp.StudentMainPage(student));
                    MessageBox.Show($"авторизация прошла успешно, добро пожаловать {student.surname} {student.name} {student.patronymic}");
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
    }
}
