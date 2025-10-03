using Examination_System.QuestionsAndAnswers;
using Examination_System.School;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Examination
{
    enum ExamMode
    {
        None,
        Starting,
        Queued,
        Finished
    }
    internal abstract class Exam : IComparable<Exam>
    {
        DateTime date;
        int duration; // in minutes
        int numberOfQuestions;
        Enum mode = ExamMode.None;
        protected int studentMarks = 0;
        public Dictionary<Question, AnswerList> questionsAndAnswers = new Dictionary<Question, AnswerList>();

        // Event to notify when the exam mode changes
        public event EventHandler ExamModeChanged;

        public Subject Subject { get; set; }

        public Exam(DateTime date, int duration, int numberOfQuestions, Subject _subject)
        {
            this.Date = date;
            this.Duration = duration;
            this.NumberOfQuestions = numberOfQuestions;
            this.Subject = _subject;
            this.Subject.Students.ForEach(s => this.ExamModeChanged += s.OnExamModeChanged);
        }

        public int Duration { get => duration; set => duration = value; }
        public int NumberOfQuestions { get => numberOfQuestions; set => numberOfQuestions = value; }
        public DateTime Date { get => date; set => date = value; }
        public Enum Mode
        {
            get => mode;
            set
            {
                mode = value;
                ExamModeChanged?.Invoke(this, EventArgs.Empty);
            }
        }

       

        // IComparable implementation - Compare by Date, then by Duration
        public int CompareTo(Exam other)
        {
            if (other == null) return 1;

            int dateComparison = Date.CompareTo(other.Date);
            if (dateComparison != 0) return dateComparison;

            return Duration.CompareTo(other.Duration);
        }

        // Override Equals
        public override bool Equals(object obj)
        {
            if (obj is Exam other)
            {
                return Date == other.Date &&
                       Duration == other.Duration &&
                       NumberOfQuestions == other.NumberOfQuestions &&
                       Subject?.Name == other.Subject?.Name;
            }
            return false;
        }

        // Override GetHashCode
        public override int GetHashCode()
        {
            return HashCode.Combine(Date, Duration, NumberOfQuestions, Subject?.Name);
        }

        // Override ToString
        public override string ToString()
        {
            return $"Exam for {Subject?.Name} on {Date:yyyy-MM-dd} ({Duration} minutes, {NumberOfQuestions} questions)";
        }

        public abstract void ShowExam();

        protected int CalculateTotalMarks()
        {
            int totalMarks = 0;
            foreach (var q in questionsAndAnswers.Keys)
            {
                totalMarks += q.Marks;
            }
            return totalMarks;
        }

        protected bool EvaluateStudentAnswer(Question question, AnswerList studentAnswer)
        {
            bool isCorrect = true;
            if (studentAnswer.Count != question.Answers.Count)
            {
                isCorrect = false;
            }
            else
            {
                foreach (var ans in question.Answers)
                {
                    if (!studentAnswer.Any(a => a.AnswerText == ans.AnswerText))
                    {
                        isCorrect = false;
                        break;
                    }
                }
            }
            if (isCorrect)
            {
                studentMarks += question.Marks;
            }
            return isCorrect;
        }
    }

}
