using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInfoSystem
{
    class Student
    {
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public String Faculty { get; set; }
        public String Speciality { get; set; }
        public Degree StudentDegree { get; set; }
        public Status StudentStatus { get; set; }
        public String FacultyNumber { get; set; }
        public ushort Course { get; set; }
        public ushort Group { get; set; }
        public ushort Stream { get; set; }
    }

    enum Status
    {
        CERTIFIED, DROPOUT, SEMESTRIAL_GRADUATED
    }

    enum Degree
    {
        BACHELOR, MAJOR, PHD, PROFESSOR
    }
}
