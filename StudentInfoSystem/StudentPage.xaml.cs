using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
    /// Interaction logic for StudentPage.xaml
    /// </summary>
    public partial class StudentPage : Page, INotifyPropertyChanged
    {
        public StudentPage()
        {
            InitializeComponent();
        }

        private Student _student;

        public event PropertyChangedEventHandler PropertyChanged;

        public Student Student 
        { 
            get
            {
                return _student;
            } 
            set
            {
                if(value != null && !value.isEmpty())
                {
                    enableBoxes(getAllBoxes());
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Student"));
                    }
                    this.DataContext = value;
                    _student = value;
                    //showStudent(value);
                }
                else
                {
                    clearBoxes(getAllBoxes());
                    disableBoxes(getAllBoxes());
                }
            } 
        }

        private List<TextBox> getAllBoxes()
        {
            var names = personalInformation.Children.OfType<TextBox>().ToList();
            var administrativeStudent = studentInformation.Children.OfType<TextBox>();
            names.AddRange(administrativeStudent);
            return names;
        }

        private void Button_Click_Clear(object sender, RoutedEventArgs e)
        {
            clearBoxes(getAllBoxes());
        }


        private void Button_Click_Disable(object sender, RoutedEventArgs e)
        {
            disableBoxes(getAllBoxes());
        }

        private void Button_Click_Enable(object sender, RoutedEventArgs e)
        {
            enableBoxes(getAllBoxes());
        }

        private void disableBoxes(List<TextBox> boxes)
        {
            foreach (var textBox in boxes)
            {
                textBox.IsEnabled = false;
            }
        }

        private void enableBoxes(List<TextBox> boxes)
        {
            foreach (var textBox in boxes)
            {
                textBox.IsEnabled = true;
            }
        }
        private void clearBoxes(List<TextBox> boxes)
        {
            foreach (var textBox in boxes)
            {
                textBox.Text = "";
            }
        }

        private void Button_Click_ShowStudent(object sender, RoutedEventArgs e)
        {
            var student = StudentData.TestStudents[0];
            showStudent(student);
        }

        private void showStudent(Student student)
        {
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
