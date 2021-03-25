using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WPFhello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var james = new ListBoxItem();
            var david = new ListBoxItem();
            james.Content = "James";
            david.Content = "David";
            peopleListBox.Items.Add(james);
            peopleListBox.Items.Add(david);
            peopleListBox.SelectedItem = james;
        }

        void MainWindow_Closing(object sender, CancelEventArgs e)
        {

            var result = MessageBox.Show("Приложението ще се затвори!", "Сигурен ли сте, че искате да затворите приложението?", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if(result == MessageBoxResult.No) {
                e.Cancel = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var names = nameStack.Children.OfType<TextBox>().Select(t =>
                {
                    if (t.Text.Length <= 2)
                    {
                        throw new ArgumentException("Всички имена трябва да са поне 2 символа дълги!");
                    }
                    return t.Text;
                } ).Aggregate("", (current, next) => current + " " + next);
                MessageBox.Show("Здрасти " + names + "!!\n Това е твоята първа програма на VS 2019");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }       
        }

        private void Button_Click_Calc(object sender, RoutedEventArgs e)
        {
            try
            {
                var number = Int32.Parse(numberBox.Text);
                var power = Int32.Parse(powerBox.Text);
                MessageBox.Show(String.Format("{0} на степен {1} е равно на {2}", number, power, Math.Pow(number, power)));
            } 
            catch(FormatException ex)
            {
                MessageBox.Show("Полетата за основа и степен трябва да са цели числа");
            }
            catch(ArgumentNullException ex)
            {
                MessageBox.Show("Полетата за основа и степен не трябва да са празни");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Oh, hi " + (peopleListBox.SelectedItem as ListBoxItem).Content.ToString());
        }

        private void ShowMessage(object sender, RoutedEventArgs e)
        {
            var otherWindow = new MyMessage();
            otherWindow.Show();
        }
    }
}
