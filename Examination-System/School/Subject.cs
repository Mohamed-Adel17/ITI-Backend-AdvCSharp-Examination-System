using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.School
{
    internal class Subject : ICloneable, IComparable<Subject>
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();

        // Constructor chaining
        public Subject() : this("")
        {
        }

        public Subject(string name)
        {
            Name = name;
        }

        // ICloneable implementation
        public object Clone()
        {
            Subject clonedSubject = new Subject(Name);

            // Deep clone the Students list
            clonedSubject.Students = new List<Student>();
            foreach (var student in Students)
            {
                clonedSubject.Students.Add((Student)student.Clone());
            }

            return clonedSubject;
        }

        // IComparable implementation
        public int CompareTo(Subject other)
        {
            if (other == null) return 1;
            return string.Compare(Name, other.Name, StringComparison.Ordinal);
        }

        // Override Equals
        public override bool Equals(object obj)
        {
            if (obj is Subject other)
            {
                return Name == other.Name;
            }
            return false;
        }

        // Override GetHashCode
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        // Override ToString
        public override string ToString()
        {
            return $"Subject: {Name} ({Students.Count} students enrolled)";
        }
    }
}
