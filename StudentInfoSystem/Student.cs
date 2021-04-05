using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInfoSystem
{
    public class Student
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

        internal bool isEmpty()
        {
            return FirstName == null && MiddleName == null && LastName == null && Faculty == null && Speciality == null;
        }
        public override string ToString()
        {
            return FirstName + " " + MiddleName + " " + LastName + " N#:" + FacultyNumber;
        }
    }

    public enum Status
    {
        CERTIFIED, DROPOUT, SEMESTRIAL_GRADUATED
    }

    public enum Degree
    {
        BACHELOR, MAJOR, PHD, PROFESSOR
    }   
}
