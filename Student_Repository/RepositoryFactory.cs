using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Repository
{
    public enum ContextTypes { XMLSource }

    public static class RepositoryFactory
    {
        public static TRepository Create<TRepository>(ContextTypes contextType) where TRepository : class
        {
            if (contextType == ContextTypes.XMLSource)
            {
                if (typeof(TRepository) == typeof(IStudentRepository))
                    return new StudentXMLRepository() as TRepository;
            }
            return null;
        }
    }
}
