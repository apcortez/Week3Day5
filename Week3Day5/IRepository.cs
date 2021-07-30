using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Day5
{
    interface IRepository<T>
    {
        public List<T> Fetch();
        //public List<T> GetByTitolo(string titolo);

    }
}
