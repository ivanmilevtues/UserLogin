using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace StudentInfoSystem
{
    public class LoginParameters: INotifyPropertyChanged
    {
        private string username;
        private string password;

        public string Username {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }
        public string Password 
        { 
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        public LoginParameters(string username, string password)
        {
            Username = username;
            Password = password;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
