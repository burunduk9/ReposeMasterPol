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
using System.Windows.Navigation;
using System.Windows.Shapes;
using AtendaanceProject.WinApp;

namespace AtendaanceProject.PageApp
{
    /// <summary>
    /// Логика взаимодействия для AdminSubjectPage.xaml
    /// </summary>
    public partial class AdminSubjectPage : Page
    {
        public List<Subject> Subjects { get; set; }
        public AdminSubjectPage()
        {
            InitializeComponent();
            Subjects = new List<Subject>(ClassApp.ClassCon.Connection.Subject.Where(u => u.is_delete != true));
            this.DataContext = this;
        }

        private void txtsearchik_TextChanged(object sender, TextChangedEventArgs e)
        {
            string _searchLine = txtsearchik.Text;
            if (_searchLine == "")
            {
                ListSubject.ItemsSource = Subjects.Where(u => u.is_delete != true).ToList();
            }
            else
            {
                ListSubject.ItemsSource = Subjects.Where(u => u.title.StartsWith(_searchLine, StringComparison.OrdinalIgnoreCase) && u.is_delete != true).ToList();
            }
        }
        private void btnAddSubject_Click(object sender, RoutedEventArgs e)
        {
            AddSubjectWindow addSubject = new AddSubjectWindow();
            addSubject.Show();
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var subjectEdit = (sender as Button).DataContext as Subject;
            WinApp.EditSubjectWindow editSubject = new WinApp.EditSubjectWindow(subjectEdit);
            editSubject.Show();
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var deleteSubject = (sender as Button).DataContext as Subject;
            var deleteSubjectMessage = MessageBox.Show($"вы уверены в том, что хотите удалить {deleteSubject.title}?", "подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (deleteSubjectMessage == MessageBoxResult.Yes)
            {
                deleteSubject.is_delete = true;
                ClassApp.ClassCon.Connection.SaveChanges();
                ListSubject.ItemsSource = new List<Subject>(ClassApp.ClassCon.Connection.Subject.Where(u => u.is_delete != true).ToList());
            }
        }
    }
}
