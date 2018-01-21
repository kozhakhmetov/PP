using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Student
    {
        public string name, surname, university, faculty;
        public int gpa;
        public Student(string name = "", string surname = "", string university = "", string faculty = "", int gpa = 0) {
            this.gpa = gpa;
            this.name = name;
            this.surname = surname;
            this.university = university;
            this.faculty = faculty;
            this.gpa = gpa;
        }
        public override string ToString()
        {
            return name + " " + surname + " " + Convert.ToString(gpa) + " " + university + " " + faculty;
        }
    }
}
