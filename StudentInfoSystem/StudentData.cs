using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInfoSystem
{
    class StudentData
    {
        public static List<Student> TestStudents
        {
            get
            {

                if (students.Count == 0)
                {
                    var student = new Student();
                    student.FirstName = "Ivan";
                    student.MiddleName = "Ivaylov";
                    student.LastName = "Milev";
                    student.Speciality = "KSI";
                    student.Stream = 1;
                    student.StudentDegree = Degree.BACHELOR;
                    student.StudentStatus = Status.CERTIFIED;
                    student.FacultyNumber = "121218022";
                    student.Faculty = "FCST";
                    students.Add(student);
                }
                return students;
            }
            private set
            {
                students = value;
            }
        }

        private static List<Student> students = new List<Student>();
    }
}
