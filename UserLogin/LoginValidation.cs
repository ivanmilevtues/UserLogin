using System;
using System.Collections.Generic;
using System.Text;

namespace UserLogin
{
    class LoginValidation
    {
        public static UserRoles currentUserRole { get; private set; }

        private string username;
        private string password;
        private string errorMessage = String.Empty;

        public delegate void ActionOnError(String errorMsg);

        private ActionOnError actionOnError;

        public LoginValidation(string name, string password, ActionOnError actionOnError)
        {
            username= name;
            this.password = password;
            this.actionOnError = actionOnError;
        }

        public bool ValidateUserInput(ref User user)
        {
            currentUserRole = UserRoles.ANONYMOUS;
            if(username.Equals(String.Empty))
            {
                errorMessage = "Не е посочено потребителско име";
                actionOnError(errorMessage);
                return false;
            }
            if(password.Equals(String.Empty))
            {
                errorMessage = "Не е посочена парола";
                actionOnError(errorMessage);
                return false;
            }

            if(username.Length < 5)
            {
                errorMessage = "Потребителското име е по-късо от 5 символа";
                actionOnError(errorMessage);
                return false;
            }

            if (password.Length < 5)
            {
                errorMessage = "Паролата име е по-късо от 5 символа";
                actionOnError(errorMessage);
                return false;
            }

            user = UserData.IsUserPassCorrect(username, password);
            if(user == null)
            {
                errorMessage = "Няма намерен потребител със зададените име и парола";
                actionOnError(errorMessage);
                return false;
            }
            currentUserRole = user.Role;
            return true;
        }
    }
}
