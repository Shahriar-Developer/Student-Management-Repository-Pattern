using System;

namespace Student_Domain
{
     
    public abstract class StudentTypeCreator
    {
        public abstract StudentType CreateStudentType();

        public void Show()
        {
            StudentType studentType = CreateStudentType();
            studentType.Display();
        }
    }
}
