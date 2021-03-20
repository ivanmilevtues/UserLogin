using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

using UserLogin;

namespace StudentInfoSystem
{
    class StudentValidation
    {
        public Student GetStudentDataByUser(User user)
        {
            try
            {
                var student = StudentData.TestStudents.Find(s => s.FacultyNumber.Equals(user.FakNum));
                return student;
            } 
            catch(ArgumentNullException ae)
            {
                throw new StudentNotFoundException(String.Format("Student with id {0} was not found.", user.FakNum), ae);
            }
        }
    }

    internal class StudentNotFoundException : Exception
    {
        public StudentNotFoundException()
        {
        }

        public StudentNotFoundException(string message) : base(message)
        {
        }

        public StudentNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected StudentNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
