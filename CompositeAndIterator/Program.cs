using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeAndIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            var C1 = new Composite("C 1");

            var C11 = new Composite("C 1.1");
            var C12 = new Composite("C 1.2");

            var L111 = new Leaf("L 1.1.1");
            var C121 = new Composite("C 1.2.1");
            var L122 = new Leaf("L 1.2.2");

            var L1211 = new Leaf("L 1.2.1.1");

            C121.Add(L1211);

            C12.Add(C121);
            C12.Add(L122);

            C11.Add(L111);

            C1.Add(C11);
            C1.Add(C12);

            var iterator = C1.CreateIterator();

            while (!iterator.IsDone())
            {
                iterator.Next();
                var ci = iterator.CurrentItem();
                ci.Operation();                
            }

        }
    }
}
