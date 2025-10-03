using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.QuestionsAndAnswers
{
    internal class QuestionTrueOrFalse : Question
    {
        // Constructor chaining
        public QuestionTrueOrFalse() : base("True or False question", "", 0)
        {
        }

        public QuestionTrueOrFalse(string header, string body, int marks) : base(header, body, marks)
        {
        }
    }
}
