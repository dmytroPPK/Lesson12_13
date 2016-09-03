using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lesson12_13.Core;

namespace Lesson12_13
{
    class Program
    {
        // school
        // subjects
        private string sourceName = "";
        static void Main(string[] args)
        {
            Console.WriteLine("Home works are coming soon!!!!");

            var subjects = new Subjects();
            subjects.AddSubject("History");
            subjects.AddSubject("Math");
            subjects.AddSubject("Phisics");
            subjects.AddSubject("Sing");
            foreach (var subject in subjects.ListSubjects)
            {
                Console.WriteLine($"ID {subject.ID}, Name {subject.Name}");
            }
            Console.WriteLine(new string('-',40));

            School school = new School();
            school.AddChild("Boris", 12);
            school.AddChild("Mike", 14);
            school.AddChild("Juliya", 8);
            school.AddChild("Virginiya", 15);
            foreach (var child in school)
            {

                Console.WriteLine($"ID {(child as SchoolChild).ID}, Name {(child as SchoolChild).Name}");
            }
            Console.WriteLine(new string('-', 40));

            foreach (var item in school.GetChildWithAge(12))
            {
                SchoolChild child = item as SchoolChild;
                Console.WriteLine($"ID {child.ID}, Name {child.Name}, Age {child.Age}");

                child.AddSubject(subjects[2], 35);
                child.AddSubject(subjects[1], 15);
            }
            Console.WriteLine(new string('-', 40));

            foreach (var item in school)
            {

                SchoolChild child = item as SchoolChild;
                Console.WriteLine($"ID {child.ID}, Name {child.Name}, Age {child.Age}, AverScore {child.AverScore}");
            }
            Console.WriteLine(new string('-', 40));

            foreach (var item in school.AverageAllChilds())
            {

                Console.WriteLine($"AverScores {item}");
            }
            Console.WriteLine(new string('-', 40));

            Console.WriteLine("Tostring default");
            foreach (var item in school)
            {

                Console.WriteLine(item);
            }
            Console.WriteLine(new string('-', 40));

            Console.WriteLine("Tostring bool");
            foreach (var item in school)
            {

                Console.WriteLine((item as SchoolChild).ToString(true));
            }
            Console.WriteLine(new string('-', 40));
            Console.ReadKey();
                
        }
        public void InitSchool()
        {

        }
    }
}
