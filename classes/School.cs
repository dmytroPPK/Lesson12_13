using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12_13.Core
{
    class School : IEnumerator, IEnumerable, IDisposable
    {
        public IList<SchoolChild> ChildList { get; set; }
        private int position = -1;

        public School()
        {
            ChildList = new List<SchoolChild>();
        }
        public School(List<SchoolChild> serializeList)    //: base()
        {
            ChildList = serializeList;
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
        public IEnumerable AverageAllChilds()
        {
            foreach (var item in ChildList)
            {
                yield return item.AverScore;
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
    }
}
