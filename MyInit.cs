using Lesson12_13.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12_13
{
    static class MyInit
    {
        public static void InitDefaultData(School school, Subjects subjects)
        {
            subjects = school.GetSubjects();
            subjects.AddSubject("History");
            subjects.AddSubject("Math");
            subjects.AddSubject("Phisics");
            subjects.AddSubject("Biology");
            subjects.AddSubject("Sport");
            subjects.AddSubject("Computers");

            school.AddChild("Boris", 12);
            
            school[1].AddSubject(subjects[1], 154);
            school[1].AddSubject(subjects[2], 150);
            school[1].AddSubject(subjects[3], 234);

            school.AddChild("Mike", 14);

            school[2].AddSubject(subjects[6], 132);
            school[2].AddSubject(subjects[5], 245);
            school[2].AddSubject(subjects[4], 172);
        }
    }
}
