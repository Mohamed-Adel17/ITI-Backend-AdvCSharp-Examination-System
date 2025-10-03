using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.QuestionsAndAnswers
{
    internal class Question : ICloneable, IComparable<Question>
    {
        public string Header { get; set;}
        public string Body {  get; set; }
        public int Marks { get; set; }

        public virtual string AnswersHeader { get => "Choose from the following answers:";  }

        public AnswerList Answers { get; set; } = new AnswerList();

        // Constructor chaining
        public Question() : this("", "", 0)
        {
        }

        public Question(string header, string body, int marks)
        {
            Header = header;
            Body = body;
            Marks = marks;
        }

        // ICloneable implementation - Deep clone
        public object Clone()
        {
            Question clonedQuestion = new Question(Header, Body, Marks);

            // Deep clone the AnswerList
            clonedQuestion.Answers = new AnswerList();
            foreach (var answer in Answers)
            {
                clonedQuestion.Answers.Add((Answer)answer.Clone());
            }

            return clonedQuestion;
        }

        // IComparable implementation - Compare by Marks, then by Header
        public int CompareTo(Question other)
        {
            if (other == null) return 1;

            int marksComparison = Marks.CompareTo(other.Marks);
            if (marksComparison != 0) return marksComparison;

            return string.Compare(Header, other.Header, StringComparison.Ordinal);
        }

        // Override Equals
        public override bool Equals(object obj)
        {
            if (obj is Question other)
            {
                return Header == other.Header &&
                       Body == other.Body &&
                       Marks == other.Marks;
            }
            return false;
        }

        // Override GetHashCode
        public override int GetHashCode()
        {
            return HashCode.Combine(Header, Body, Marks);
        }

        // Override ToString
        public override string ToString()
        {
            return $"{Header}: {Body} ({Marks} marks)";
        }
    }
}
