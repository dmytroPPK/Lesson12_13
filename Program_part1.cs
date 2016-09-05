using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lesson12_13.Core;

namespace Lesson12_13
{
    partial class Program_part1
    {
        static void Main(string[] args)
        {
            Program prog = new Program("Dump1.dat", initDefaultData_: true);
            //Program prog = new Program("Dump2.dat", initDefaultData_: false);
            prog.CheckDat();
            prog.Menu();
            prog.Final();
            
        }
    }
}
