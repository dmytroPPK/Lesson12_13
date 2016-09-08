using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Lesson12_13.Core
{
    [Serializable]
    class School : IEnumerator, IEnumerable, IDisposable, ISerializable
    {
        public IList<SchoolChild> ChildList { get; set; }
        private int position = -1;
        protected Subjects subjects;

        public School()
        {
            ChildList = new List<SchoolChild>();
            subjects = new Subjects();
        }
        public Subjects GetSubjects()
        {
            return subjects;
        }
        public SchoolChild this[int indexer]
        {
            get
            {
                int indexOfChild = ChildList.IndexOf(new SchoolChild { ID = indexer });
                return (indexOfChild == -1) ? null : ChildList[indexOfChild];
            }
        }
        public void AddChild(string name = "New Child", int age = 0)
        {
            int id;
            if (ChildList.Count == 0)
            {
                id = 0;
            }
            else
            {
                id = ChildList.Max(child => child.ID);
            }
            ChildList.Add(new SchoolChild { Name = name, ID = id + 1 , Age= age});

        }
        
        //Using yield
        public IEnumerable GetChildWithAge(int age)
        {
            foreach (var item in ChildList)
            {
                if(item.Age > age)
                {
                    yield return item;
                }
            }
        }
        
        //IEnumerable
        public IEnumerator GetEnumerator()
        {
            return this;
        }
        //IEnumerator
        public object Current
        {
            get
            {
                return ChildList[position];
            }
        }


        public bool MoveNext()
        {
            if(position < ChildList.Count - 1)
            {
                ++position;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            position = -1;
        }

        public void Dispose()
        {
            Reset();
        }

        // Serializable
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(ChildList), ChildList);
            info.AddValue(nameof(this.subjects),this.subjects);
        }
        private School(SerializationInfo info, StreamingContext context)
        {
            ChildList = info.GetValue(nameof(ChildList), typeof(List<SchoolChild>)) as List<SchoolChild>;
            subjects = (Subjects)info.GetValue(nameof(subjects), typeof(Subjects));
            
        }
    }
}
