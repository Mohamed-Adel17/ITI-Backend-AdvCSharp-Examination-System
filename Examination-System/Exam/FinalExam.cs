using Examination_System.QuestionsAndAnswers;
using Examination_System.School;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Examination
{
    internal class FinalExam : Exam
    {
        public FinalExam(DateTime date, int duration, int numberOfQuestions, Subject subject) : base(date, duration, numberOfQuestions, subject)
        {
        }

        // Override ToString to show exam type
        public override string ToString()
        {
            return $"Final Exam for {Subject?.Name} on {Date:yyyy-MM-dd} ({Duration} minutes, {NumberOfQuestions} questions)";
        }
        public override void ShowExam()
        {
            int totalMarks = CalculateTotalMarks();
            Console.WriteLine($"\n-----------------Starting Final Exam in {Subject.Name}-----------------");
            Console.WriteLine($"Date: {base.Date} -- Total Marks : {totalMarks}");
            int qCounter = 1;
            foreach (var item in questionsAndAnswers)
            {
                Console.WriteLine("========================================");
                Console.WriteLine($"{item.Key.Header}\nQ{qCounter++}: {item.Key.Body}\nMarks: {item.Key.Marks}");
                Console.WriteLine("========================================");
                Console.WriteLine(item.Key.AnswersHeader);
                int answerNumber = 1;
                foreach (var _answer in item.Value)
                {
                    Console.WriteLine($"{answerNumber++}: {_answer.AnswerText}");
                }
                Console.WriteLine();

                List<int> answer;
                while (true)
                {
                    Console.Write($"Your Choice: ");
                    try
                    {
                        answer = Console.ReadLine()
                                            .Split(',')
                                            .Select(s => s.Trim())
                                            .Where(s => s != "")
                                            .Select(int.Parse)
                                            .ToList();

                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Invalid input. Please enter your choices as comma-separated numbers.");
                        Console.ResetColor();
                        continue;
                    }
                    break;
                }

                AnswerList studentAnswer = new AnswerList();
                foreach (var ans in answer)
                {
                    if (ans > 0 && ans <= item.Value.Count)
                        studentAnswer.Add(item.Value[ans - 1]);
                }
                EvaluateStudentAnswer(item.Key, studentAnswer);
                Console.WriteLine("-------------------------------------");
                Console.WriteLine();
            }
            Console.WriteLine("====================================================");
            Console.WriteLine($"Your Total Marks: {studentMarks} out of {totalMarks}");
            Console.WriteLine("====================================================");
            Console.WriteLine("-----------------Exam Finished-----------------");
        }
    }
}
