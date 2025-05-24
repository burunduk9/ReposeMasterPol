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
        public static Groupi group1 = new Groupi();
        public static List<Speciality> specialitys { get; set; }
        public EditGroupWindow(Groupi groupEdit)
        {
            InitializeComponent();
            specialitys = new List<Speciality>(ClassApp.ClassCon.Connection.Speciality.Where(u => u.is_delete != true).ToList());
            group1 = groupEdit;
            txtGroupTitle.Text = group1.title;
            txtGroupCourse.Text = (group1.course).ToString();
            CBSpeciality.SelectedItem = specialitys.FirstOrDefault(u => u.id == group1.Speciality.id);
            this.DataContext = this;
        }

        private void btnLeave_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            group1.title = txtGroupTitle.Text;
            group1.course = Convert.ToInt32(txtGroupCourse.Text);
            group1.id_speciality = (CBSpeciality.SelectedItem as Speciality).id;
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
    }
}
