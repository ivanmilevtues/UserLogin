using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using UserLogin;

namespace StudentInfoSystem
{
    internal class UserLoginCommand : ICommand
    {
        private UserLoginViewModel _ViewModel;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public UserLoginCommand(UserLoginViewModel viewModel)
        {
            _ViewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return _ViewModel.IsLoginEnabled();
        }

        public void Execute(object parameter)
        {
            _ViewModel.Login();
        }
    }
}
