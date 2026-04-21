using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Domain
{
    public class GraduateStudent : StudentType
    {
        public override void Display()
        {
            Console.WriteLine("This is a Graduate Student (Method Pattern).");
        }
    }
}

