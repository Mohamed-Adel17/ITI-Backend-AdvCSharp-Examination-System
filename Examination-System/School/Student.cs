using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examination_System.Examination;
namespace Examination_System.School
{
    internal class Student : ICloneable, IComparable<Student>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Subject> EnrolledSubjects { get; set; } = new List<Subject>();

        // Constructor chaining
        public Student() : this(0, "")
        {
        }

        public Student(int id, string name)
        {
            Id = id;
            Name = name;
        }

        // ICloneable implementation - Deep clone
        public object Clone()
        {
            Student clonedStudent = new Student(Id, Name);

            // Deep clone the EnrolledSubjects list
            clonedStudent.EnrolledSubjects = new List<Subject>();
            foreach (var subject in EnrolledSubjects)
            {
                clonedStudent.EnrolledSubjects.Add((Subject)subject.Clone());
            }

            return clonedStudent;
        }

        // IComparable implementation
        public int CompareTo(Student other)
        {
            if (other == null) return 1;

            int idComparison = Id.CompareTo(other.Id);
            if (idComparison != 0) return idComparison;

            return string.Compare(Name, other.Name, StringComparison.Ordinal);
        }

        // Override Equals
        public override bool Equals(object obj)
        {
            if (obj is Student other)
            {
                return Id == other.Id && Name == other.Name;
            }
            return false;
        }

        // Override GetHashCode
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }

        // Override ToString
        public override string ToString()
        {
            return $"Student ID: {Id}, Name: {Name}";
        }

        // Event handler for exam mode change
        public void OnExamModeChanged(object? sender, EventArgs e)
        {
            var obj = sender as Exam;
            if (obj != null)
            {
                Console.WriteLine($"Student {Name} notified: Exam mode changed to {obj.Mode}");
            }
        }

        public void EnrollSubject(Subject subject)
        {
            EnrolledSubjects.Add(subject);
            subject.Students.Add(this);
        }
    }
}
