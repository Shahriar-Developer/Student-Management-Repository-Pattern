using System;

namespace Student_Domain
{
    public class GraduateCreator : StudentTypeCreator
    {
        public override StudentType CreateStudentType()
        {
            return new GraduateStudent();
        }
    }
}
