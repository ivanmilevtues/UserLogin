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

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private List<TextBox> getAllBoxes()
        {
            var names = nameStack.Children.OfType<TextBox>().ToList();
            var administrativeStudent = administrativeStudentInfo.Children.OfType<TextBox>();
            var studentInfo = studentStack.Children.OfType<TextBox>();
            names.AddRange(administrativeStudent);
            names.AddRange(studentInfo);
            return names;
        }

        private void Button_Click_Clear(object sender, RoutedEventArgs e)
        {
            foreach(var textBox in getAllBoxes())
            {
                textBox.Text = "";
            }
        }

        private void Button_Click_Disable(object sender, RoutedEventArgs e)
        {
            foreach (var textBox in getAllBoxes())
            {
                textBox.IsEnabled = false;
            }
        }

        private void Button_Click_Enable(object sender, RoutedEventArgs e)
        {
            foreach (var textBox in getAllBoxes())
            {
                textBox.IsEnabled = true;
            }
        }

        private void Button_Click_ShowStudent(object sender, RoutedEventArgs e)
        {
            var student = StudentData.TestStudents[0];
            firstName.Text = student.FirstName;
            middleName.Text = student.MiddleName;
            lastName.Text = student.LastName;

            faculty.Text = student.Faculty;
            facultyNumber.Text = student.FacultyNumber;
            speciality.Text = student.Speciality;
            OKS.Text = student.StudentDegree.ToString();
            status.Text = student.StudentStatus.ToString();
            course.Text = student.Course.ToString();
            group.Text = student.Group.ToString();
            stream.Text = student.Stream.ToString();
        }
    }
}
