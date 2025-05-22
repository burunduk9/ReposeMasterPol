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
using AtendaanceProject.ADOApp;

namespace AtendaanceProject.PageApp
{
    /// <summary>
    /// Логика взаимодействия для AdminSpecialityPage.xaml
    /// </summary>
    public partial class AdminSpecialityPage : Page
    {
        public List<Speciality> Specialitys { get; set; }
        public AdminSpecialityPage()
        {
            InitializeComponent();
            Specialitys = new List<Speciality>(ClassApp.ClassCon.Connection.Speciality);
            this.DataContext = this;
        }

        private void txtsearchik_TextChanged(object sender, TextChangedEventArgs e)
        {
            string _searchLine = txtsearchik.Text;
            if (_searchLine == "")
            {
                ListSpeciality.ItemsSource = Specialitys.ToList();
            }
            else
            {
                ListSpeciality.ItemsSource = Specialitys.Where(u => u.title.StartsWith(_searchLine, StringComparison.OrdinalIgnoreCase)).ToList();
            }
        }
        private void btnAddSpeciality_Click(object sender, RoutedEventArgs e)
        {
            var addSpecialityWindow = new WinApp.AddSpecialityWindow();
            addSpecialityWindow.Show();
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var specialityEdit = (sender as Button).DataContext as Speciality;
            var editSpecialityWindow = new WinApp.EditSpecialityWindow { DataContext = specialityEdit };
            if (editSpecialityWindow.ShowDialog() == true)
            {
                ListSpeciality.ItemsSource = new List<Speciality>(ClassApp.ClassCon.Connection.Speciality.Where(u => u.is_delete != true).ToList());
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var deleteSpeciality = (sender as Button).DataContext as Speciality;
            var deleteSpecialityMessage = MessageBox.Show($"вы уверены в том, что хотите удалить {deleteSpeciality.title}?", 
                "подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (deleteSpecialityMessage == MessageBoxResult.Yes)
            {
                deleteSpeciality.is_delete = true;
                ClassApp.ClassCon.Connection.SaveChanges();
                ListSpeciality.ItemsSource = new List<Speciality>(ClassApp.ClassCon.Connection.Speciality.Where(u => u.is_delete != true).ToList());
            }
        }
    }
}
