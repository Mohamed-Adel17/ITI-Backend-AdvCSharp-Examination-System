using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.QuestionsAndAnswers
{
    internal class QuestionChooseAll : Question
    {
        public override string AnswersHeader { get => "Choose all that apply from the following answers (separated with comma ','):"; }

        // Constructor chaining
        public QuestionChooseAll() : base("Choose all question", "", 0)
        {
        }

        public QuestionChooseAll(string header, string body, int marks) : base(header, body, marks)
        {
        }
    }
}
