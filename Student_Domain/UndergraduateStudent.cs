using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Domain
{
    public class UndergraduateStudent : StudentType
    {
        public override void Display()
        {
            Console.WriteLine("This is an Undergraduate Student (Method Pattern).");
        }
    }
}

