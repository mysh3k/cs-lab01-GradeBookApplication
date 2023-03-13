using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool boolean) : base(name, boolean)
        {
            base.Type = Enums.GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException();

            int worseThanMe = 0;
            for (int i = 0; i < Students.Count; i++)
            {
                if (averageGrade > Students[i].AverageGrade)
                {
                    worseThanMe++;
                }
            }

            int howManyIs20Percent = Students.Count / 5;
            if (worseThanMe >= howManyIs20Percent * 4)
                return 'A';
            else if (worseThanMe < howManyIs20Percent * 4 && worseThanMe >= howManyIs20Percent * 3)
                return 'B';
            else if (worseThanMe < howManyIs20Percent * 3 && worseThanMe >= howManyIs20Percent * 2)
                return 'C';
            else if (worseThanMe < howManyIs20Percent * 2 && worseThanMe >= howManyIs20Percent * 1)
                return 'D';
            else
                return 'F';
        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine($"Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStatistics();
            }
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine($"Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}
