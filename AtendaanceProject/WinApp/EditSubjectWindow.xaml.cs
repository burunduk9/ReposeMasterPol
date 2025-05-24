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
    /// Логика взаимодействия для EditSubjectWindow.xaml
    /// </summary>
    public partial class EditSubjectWindow : Window
    {
        public static Subject subject1 = new Subject();
        public EditSubjectWindow(Subject subjectEdit)
        {
            InitializeComponent();
            subject1 = subjectEdit;
            txtTitle.Text = subject1.title;
            txtDescription.Text = subject1.description;
            this.DataContext = this;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            subject1.title = txtTitle.Text;
            subject1.description = txtDescription.Text;
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
