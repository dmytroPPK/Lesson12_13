using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12_13.Core
{
    [Serializable]
    class SchoolChild
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double AverScore { get { return AverageScore(); } }
        //public IDictionary<Subject, double> OwnSubjects => ownSubjects;
        private IDictionary<Subject, double> ownSubjects;

        public SchoolChild()
        {
            ownSubjects = new Dictionary<Subject, double>();
        }

        private double AverageScore()
        {
            if(ownSubjects.Count == 0)
            {
                return 0D;
            }else
            {
                return ownSubjects.Values.Average();
            }
        }


        public void AddSubject(Subject subject, double score)
        {
            if (!ownSubjects.ContainsKey(subject) && subject != null)
            {
                ownSubjects.Add(subject,score);

            }else
            {
                throw new ArgumentException("This subject exists");
            }
        }
        public override int GetHashCode()
        {
            return (ID.ToString() + "My salt").GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
        }
        public override string ToString() => $"ID {ID}, Name {Name}, Age {Age}, AverScore {AverScore:F}";
        
        public string ToString(bool viewSubjectsScore )
        {
            if (viewSubjectsScore)
            {
                string dataStr = $"Name {Name}, Age {Age}, AverScore {AverScore:F}\n";
                if(ownSubjects.Count == 0)
                {
                    dataStr += "\tThis child has not the subjects";
                }
                else
                {
                    foreach (var item in ownSubjects)
                    {
                        dataStr += $"\tSubject {item.Key.Name},Score {item.Value} \n";
                    }
                }
                return dataStr;

            }
            else
            {
                return ToString();
            }
        }
    }
}
