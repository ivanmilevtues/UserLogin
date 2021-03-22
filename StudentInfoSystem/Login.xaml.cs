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
using UserLogin;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var validation = new LoginValidation(username.Text, password.Text, errorAction);
            User user = null;
            if(validation.ValidateUserInput(ref user))
            {
                var page = new StudentPage();
                if(user.Role == UserRoles.STUDENT)
                {
                    var studentValidation = new StudentValidation();
                    try
                    {
                        page.Student = studentValidation.GetStudentDataByUser(user);
                    }
                    catch (ArgumentException ex)
                    {
                        page.Student = null;
                    }
                } else
                {
                    page.Student = null;
                }
                navigateTo(page);
            }

        }

        private void navigateTo(Page otherPage)
        {
            Frame pageFrame = null;
            DependencyObject currParent = VisualTreeHelper.GetParent(this);

            while (currParent != null && pageFrame == null)
            {
                pageFrame = currParent as Frame;
                currParent = VisualTreeHelper.GetParent(currParent);
            }

            // Change the page of the frame.
            if (pageFrame != null)
            {
                pageFrame.Navigate(otherPage);
            }
        }

        static private void errorAction(String error)
        {
            MessageBox.Show(error, "Проблем при влизането:");
        }
    }
}
