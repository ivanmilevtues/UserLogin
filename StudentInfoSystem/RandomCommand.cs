using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace StudentInfoSystem
{
    class RandomCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var block = parameter as TextBlock;
            block.Text = "You are using old version of the product";
            block.Foreground = Brushes.Red;
            block.FontSize = 15;
        }
    }
}
