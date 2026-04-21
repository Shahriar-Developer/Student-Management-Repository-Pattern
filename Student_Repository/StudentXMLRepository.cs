using Student_Domain;
using Student_Source;

namespace Student_Repository
{
    public class StudentXMLRepository : XMLRepositoryBase<XMLSet<Student>, Student, int>, IStudentRepository
    {
        public StudentXMLRepository() : base("StudentInformation.xml") { }
    }
}
