using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.QuestionsAndAnswers
{
    internal class Answer : ICloneable, IComparable<Answer>
    {
        string answerText = "";
        public string AnswerText
        {
            get { return answerText; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Answer text cannot be null or empty.");
                }
                answerText = value;
            }
        }

        // Constructor chaining
        public Answer()
        {
        }

        public Answer(string text)
        {
            AnswerText = text;
        }

        // ICloneable implementation
        public object Clone()
        {
            return new Answer(AnswerText);
        }

        // IComparable implementation
        public int CompareTo(Answer other)
        {
            if (other == null) return 1;
            return string.Compare(AnswerText, other.AnswerText, StringComparison.Ordinal);
        }

        // Override Equals
        public override bool Equals(object obj)
        {
            if (obj is Answer other)
            {
                return AnswerText == other.AnswerText;
            }
            return false;
        }

        // Override GetHashCode
        public override int GetHashCode()
        {
            return AnswerText.GetHashCode();
        }

        public override string ToString()
        {
            return AnswerText;
        }
    }
    internal class AnswerList : List<Answer>, ICloneable
    {
        public AnswerList() : base()
        {
        }

        public AnswerList(IEnumerable<Answer> collection) : base(collection)
        {
        }

        public new void Add(Answer answer)
        {
            if (answer == null)
            {
                throw new ArgumentNullException(nameof(answer), "Answer cannot be null.");
            }
            base.Add(answer);
        }

        // ICloneable implementation
        public object Clone()
        {
            AnswerList clonedList = new AnswerList();
            foreach (var answer in this)
            {
                clonedList.Add((Answer)answer.Clone());
            }
            return clonedList;
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < this.Count; i++)
            {
                result += this[i].AnswerText;
                if (i < this.Count - 1)
                {
                    result += ", ";
                }
            }
            return result;
        }
    }
}
