using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UserLogin;

namespace StudentInfoSystem
{
    class UserLoginViewModel
    {

        private Login loginWindow;

        public UserLoginViewModel(Login login)
        {
            loginWindow = login;
            LoginCommand = new UserLoginCommand(this); 
            LoginParameters = new LoginParameters("", "");
            RandomCommand = new RandomCommand();
        }

        public LoginParameters LoginParameters { get; private set;}

        public ICommand RandomCommand
        {
            get;
            private set;
        }

        public ICommand LoginCommand
        {
            get;
            private set;
        }

        public void Login()
        {
            var validation = new LoginValidation(LoginParameters.Username, LoginParameters.Password, errorAction);
            User user = null;
            if (validation.ValidateUserInput(ref user))
            {
                Page page = new StudentPage();
                if (user.Role == UserRoles.STUDENT)
                {
                    var studentPage = page as StudentPage;
                    var studentValidation = new StudentValidation();
                    try
                    {
                        studentPage.Student = studentValidation.GetStudentDataByUser(user);
                    }
                    catch (ArgumentException ex)
                    {
                        studentPage.Student = null;
                    }
                }
                else if (user.Role == UserRoles.ADMIN)
                {
                    page = new AdminPage();
                }
                else
                {
                    page = new StudentPage();
                    MessageBox.Show("Login was unsuccessful");
                    return;
                }
                loginWindow.NavigateTo(page);
            }
        }

        internal bool IsLoginEnabled()
        {
            return !string.IsNullOrEmpty(LoginParameters.Username) && !string.IsNullOrEmpty(LoginParameters.Password);
        }

        static private void errorAction(String error)
        {
            MessageBox.Show(error, "Проблем при влизането:");
        }
    }
}
