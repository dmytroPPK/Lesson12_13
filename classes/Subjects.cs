using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12_13.Core
{
    class Subjects
    {
        private IList<Subject> listOfSubjects;
        public IList<Subject> ListSubjects => listOfSubjects;
        public Subjects()
        {
            listOfSubjects = new List<Subject>();
        }
        public Subject this[int indexer ]
        {
            get
            {
                int indexOfSubject = listOfSubjects.IndexOf(new Subject { ID= indexer});
                return (indexOfSubject == -1) ? null : listOfSubjects[indexOfSubject];
            }
        }
        public void AddSubject(string name = "New Subject")
        {
            int id;
            if (listOfSubjects.Count == 0)
            {
                id = 0;
            }
            else
            {
                id = listOfSubjects.Max(subject => subject.ID);
            }
            listOfSubjects.Add(new Subject {Name = name, ID = id+1 });
            
        }
        
        
    }
}
