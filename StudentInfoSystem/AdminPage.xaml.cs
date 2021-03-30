using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void showUsers(object sender, RoutedEventArgs e)
        {
            UserLogin.UserData.TestUsers.ForEach(u =>
            {
                usersList.Items.Add(u.ToString());
            });
        }

        private void showStudents(object sender, RoutedEventArgs e)
        {
            StudentData.TestStudents.ForEach(s =>
            {
                studentsLists.Items.Add(s.ToString());
            });
        }
    }
}
