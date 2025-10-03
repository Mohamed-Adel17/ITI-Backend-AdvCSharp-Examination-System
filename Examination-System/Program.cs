using Examination_System.QuestionsAndAnswers;
using Examination_System.Examination;
using Examination_System.School;


#region Answers
AnswerList TrueOrFalse = new AnswerList()
{
    new Answer() { AnswerText = "True" },
    new Answer() { AnswerText = "False" }
};
var a4 = new AnswerList()
{
    new Answer() { AnswerText = "int" },
    new Answer() { AnswerText = "float" },
    new Answer() { AnswerText = "string" },
    new Answer() { AnswerText = "bool" }
};
var a5 = new AnswerList()
{
    new Answer() { AnswerText = "public" },
    new Answer() { AnswerText = "private" },
    new Answer() { AnswerText = "protected" },
    new Answer() { AnswerText = "internal" }
};
var a6 = new AnswerList()
{
    new Answer() { AnswerText = "catch" },
    new Answer() { AnswerText = "finally" },
    new Answer() { AnswerText = "final" },
    new Answer() { AnswerText = "throw" }
};
var a7 = new AnswerList()
{
    new Answer() { AnswerText = "string" },
    new Answer() { AnswerText = "int" },
    new Answer() { AnswerText = "class" },
    new Answer() { AnswerText = "struct" }
};
#endregion

#region Questions
//Create some Questions 
QuestionTrueOrFalse q1 = new QuestionTrueOrFalse()
{
    Body = "The using directive is only for namespaces and cannot be used for resource disposal.",
    Marks = 1,
    Answers = new AnswerList()
    {
        new Answer() { AnswerText = "False" }
    }
};
QuestionTrueOrFalse q2 = new QuestionTrueOrFalse()
{
    Body = "string in C# is immutable",
    Marks = 1,
    Answers = new AnswerList()
    {
        new Answer() { AnswerText = "True" }
    }
};

QuestionChooseOne q4 = new QuestionChooseOne()
{
    Body = "Which of the following is not a value type in C#?",
    Marks = 2,
    Answers = new AnswerList()
    {
        new Answer() { AnswerText = "string" }
    }
};


QuestionChooseOne q5 = new QuestionChooseOne()
{
    Body = "What is the default access modifier for class members in C#?",
    Marks = 2,
    Answers = new AnswerList()
    {
        new Answer() { AnswerText = "private" },
    }
};

QuestionChooseAll q6 = new QuestionChooseAll()
{
    Body = "Which keywords are valid for exception handling blocks?",
    Marks = 2,
    Answers = new AnswerList()
    {
        new Answer() { AnswerText = "catch" },
        new Answer() { AnswerText = "finally" },
        new Answer() { AnswerText = "throw" }
    }
};
QuestionChooseAll q7 = new QuestionChooseAll()
{
    Body = "Which are reference types in C#?",
    Marks = 2,
    Answers = new AnswerList()
    {
        new Answer() { AnswerText = "string" },
        new Answer() { AnswerText = "class" }
    }
};

QuestionList questionList = new QuestionList();
questionList.Add(q1);
questionList.Add(q2);
questionList.Add(q4);
questionList.Add(q5);
questionList.Add(q6);
questionList.Add(q7);

#endregion

#region Students and Subjects
Subject math = new Subject("Math");
Subject programming = new Subject("Programming");

Student s1 = new Student(1, "Omar");
s1.EnrollSubject(math);
s1.EnrollSubject(programming);

Student s2 = new Student(2, "Ahmed");
s2.EnrollSubject(math);

Student s3 = new Student(3, "Sara");
s3.EnrollSubject(programming);

Student s4 = new Student(4, "Lina");
s4.EnrollSubject(programming);

#endregion


Console.WriteLine("Choose the exam type : ");
Console.WriteLine("1. Final Exam");
Console.WriteLine("2. Practice Exam");
int choice;
while (true)
{
    Console.Write("Your Choice: ");
    if(int.TryParse(Console.ReadLine(), out choice) && (choice == 1 || choice == 2))
            break;
    else
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Invalid choice. Please enter 1 or 2.");
        Console.ResetColor();
        continue;
    }
}

Exam exam;
if (choice == 1)
    exam = new FinalExam(DateTime.Now, 120, questionList.Count, programming);
else
    exam = new PracticeExam(DateTime.Now, 120, questionList.Count, programming);

exam.questionsAndAnswers.Add(questionList[0], TrueOrFalse);
exam.questionsAndAnswers.Add(questionList[1], TrueOrFalse);
exam.questionsAndAnswers.Add(questionList[2], a4);
exam.questionsAndAnswers.Add(questionList[3], a5);
exam.questionsAndAnswers.Add(questionList[4], a6);
exam.questionsAndAnswers.Add(questionList[5], a7);

exam.Mode = ExamMode.Starting;
exam.ShowExam();
exam.Mode = ExamMode.Finished;








