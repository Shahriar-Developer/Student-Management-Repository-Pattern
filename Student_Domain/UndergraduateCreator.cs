using System;

namespace Student_Domain
{
    public class UndergraduateCreator : StudentTypeCreator
    {
        public override StudentType CreateStudentType()
        {
            return new UndergraduateStudent();
        }
    }
}
