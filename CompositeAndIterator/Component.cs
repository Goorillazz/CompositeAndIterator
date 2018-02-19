using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CompositeAndIterator
{
    public abstract class Component
    {
        public List<Component> Components { get; } = new List<Component>();

        public abstract void Operation();
        public abstract void Add(Component component);
        public abstract void Remove(Component component);

        public Component GetChild(int index)
        {
            var indexOfReturened = 0;
            var componentsCount = Components.Count;
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

            return Components.ElementAt(indexOfReturened);
        }

        public Iterator<Component> CreateIterator()
        {
            return new ComponentIterator(this);
        }
    }

    public class ComponentIterator : Iterator<Component>
    {
        private readonly Component _root;
        private readonly List<Component> _list;
        private readonly int _count;
        private Component _currentComponent;
        private int _index;

        public ComponentIterator(Component root)
        {
            _root = root;
            _currentComponent = _root;
            _list = CreateList();
            _count = _list.Count;
            Reset();
        }

        public void Reset()
        {
            _index = 0;
            _currentComponent = _list.ElementAt(0);
        }

        public void Next()
        {
            if (_index > _count - 1)
            {
                throw new Exception("End of Index.");
            }
            else
            {
                _currentComponent = _list.ElementAt(_index);
            }
            _index++;
        }

        public bool IsDone()
        {
            return _index >= _count;
        }

        public Component CurrentItem()
        {
            return _currentComponent;
        }
        private List<Component> CreateList()
        {
            var list = new List<Component>();
            FillList(list, _root);
            return list;
        }

        private static void FillList(List<Component> list, Component componentOfThisLevel)
        {
            if (componentOfThisLevel.Components.Any())
            {
                foreach (var comp in componentOfThisLevel.Components)
                {
                    FillList(list, comp);
                }
            }
            else
            {
                list.Add(componentOfThisLevel);
            }
        }
    }
}
