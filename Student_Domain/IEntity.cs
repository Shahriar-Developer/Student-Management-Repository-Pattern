using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Domain
{
    public interface IEntity<TKey>
    {
        TKey ID { get; set; }
    }
}

