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
    /// Логика взаимодействия для AdminGroupPage.xaml
    /// </summary>
    public partial class AdminGroupPage : Page
    {
        public List<Groupi> Groups { get; set; }
        public List<Speciality> Specialitys { get; set; }
        public AdminGroupPage()
        {
            InitializeComponent();
            Groups = new List<Groupi>(ClassApp.ClassCon.Connection.Groupi);
            Specialitys = new List<Speciality>(ClassApp.ClassCon.Connection.Speciality);
            Specialitys.Insert(0, new Speciality() { id = -1, title = "all" });
            this.DataContext = this;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var groupEdit = (sender as Button).DataContext as Groupi;
            var editGroupWindow = new WinApp.EditGroupWindow { DataContext = groupEdit };
            if (editGroupWindow.ShowDialog() == true)
            {
                ListGroup.ItemsSource = new List<Groupi>(ClassApp.ClassCon.Connection.Groupi.Where(u => u.is_delete != true).ToList());
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var deleteGroup = (sender as Button).DataContext as Groupi;
            var deleteGroupMessage = MessageBox.Show($"вы уверены в том, что хотите удалить {deleteGroup.title}?", 
                "подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (deleteGroupMessage == MessageBoxResult.Yes)
            {
                deleteGroup.is_delete = true;
                ClassApp.ClassCon.Connection.SaveChanges();
                ListGroup.ItemsSource = new List<Groupi>(ClassApp.ClassCon.Connection.Groupi.Where(u => u.is_delete != true).ToList());
            }
        }
        private void btnAddGroup_Click(object sender, RoutedEventArgs e)
        {
            var addGroupWindow = new WinApp.AddGroupWindow();
            addGroupWindow.Show();
        }
        private void txtsearchik_TextChanged(object sender, TextChangedEventArgs e)
        {
            string _searchLine = txtsearchik.Text;
            if (_searchLine == "")
            {
                ListGroup.ItemsSource = Groups.ToList();
            }
            else
            {
                ListGroup.ItemsSource = Groups.Where(u => u.title.StartsWith(_searchLine, StringComparison.OrdinalIgnoreCase)).ToList();
            }
        }
        private void CBfilterSpeciality_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedSpeciaility = CBfilterSpeciality.SelectedItem as Speciality;
            if (selectedSpeciaility.id != -1)
            {
                ListGroup.ItemsSource = Groups.Where(u => u.id_speciality == selectedSpeciaility.id).ToList();
            }
            else
            {
                ListGroup.ItemsSource = Groups.ToList();
            }
        }
    }
}
