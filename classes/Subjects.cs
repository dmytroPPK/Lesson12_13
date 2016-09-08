using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12_13.Core
{
    [Serializable]
    class Subjects
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public override int GetHashCode()
        {
            return (ID.ToString() + "My salt subject").GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
        }

        private IList<Subjects> listOfSubjects;
        public IList<Subjects> ListSubjects => listOfSubjects;
        public Subjects()
        {
            listOfSubjects = new List<Subjects>();
        }
        public Subjects this[int indexer ]
        {
            get
            {
                int indexOfSubject = listOfSubjects.IndexOf(new Subjects { ID= indexer});
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
            listOfSubjects.Add(new Subjects {Name = name, ID = id+1 });
            
        }
        
        
    }
}
