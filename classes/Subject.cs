using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12_13.Core
{
    class Subject
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public override int GetHashCode()
        {
            return (ID.ToString() + "My salt").GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return this.GetHashCode()==obj.GetHashCode(); 
        }
    }
}
