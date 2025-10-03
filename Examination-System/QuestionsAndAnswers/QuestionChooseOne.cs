using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.QuestionsAndAnswers
{
    internal class QuestionChooseOne : Question
    {
        public override string AnswersHeader { get => "Choose one from the following answers:"; }

        // Constructor chaining
        public QuestionChooseOne() : base("Choose one question", "", 0)
        {
        }

        public QuestionChooseOne(string header, string body, int marks) : base(header, body, marks)
        {
        }
    }
}
