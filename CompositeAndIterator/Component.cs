using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeAndIterator
{
    public abstract class Component
    {

        protected List<Component> _components = new List<Component>();

        public abstract void Operation();
        public abstract void Add(Component component);
        public abstract void Remove(Component component);

        public Component GetChild(int index)
        {
            var indexOfReturened = 0;
            var componentsCount = _components.Count;
            if (componentsCount == 0)
                return null;

            if (index < 0)
            {
                indexOfReturened = 0;
            }
            else if (index > componentsCount - 1)
            {
                indexOfReturened = componentsCount - 1;
            }

            return _components.ElementAt(indexOfReturened);
        }
    }
}
