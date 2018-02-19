using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeAndIterator
{
    public interface Iterator<T>
    {
        void Reset();
        void Next();
        bool IsDone();
        T CurrentItem();
    }
}
