using System;
using System.Collections.Generic;
using System.Linq;
namespace SRPDemo
{
    public class Student
    {
        public string Name { get; set; }
        public Dictionary<string, double> CoursesAndGrades = new Dictionary<string, double>();

        public void EnrollCourse(string courseName)
        {
            CoursesAndGrades[courseName] = 0; // default grade
        }

        public void AssignGrade(string courseName, double grade)
        {
            if (CoursesAndGrades.ContainsKey(courseName))
            {
                CoursesAndGrades[courseName] = grade;
            }
        }
    }

    public class GPACalculator
    {
        public double CalculateGPA(Student student)
        {
            // Basic GPA calculation logic
            return student.CoursesAndGrades.Values.Average();
        }
    }

    public class TranscriptGenerator
    {
        private GPACalculator _gpaCalculator;

        public TranscriptGenerator(GPACalculator gpaCalculator)
        {
            _gpaCalculator = gpaCalculator;
        }

        public void PrintTranscript(Student student)
        {
            Console.WriteLine($"Transcript for {student.Name}");
            foreach (var course in student.CoursesAndGrades)
            {
                Console.WriteLine($"{course.Key}: {course.Value}");
            }
            Console.WriteLine($"GPA: {_gpaCalculator.CalculateGPA(student)}");
        }
    }

    //Testing the Single Responsibility Principle
    public class Program
    {
        public static void Main()
        {
            Student alice = new Student { Name = "Alice" };
            alice.EnrollCourse("Mathematics");
            alice.AssignGrade("Mathematics", 90);
            alice.EnrollCourse("Science");
            alice.AssignGrade("Science", 30);

            GPACalculator gpaCalc = new GPACalculator();
            TranscriptGenerator transcriptGen = new TranscriptGenerator(gpaCalc);
            transcriptGen.PrintTranscript(alice);

            Console.ReadKey();
        }
    }
}