using System;

namespace CompositeAndIterator
{
    public class Composite : Component
    {
        private readonly string _message;

        public Composite(string message)
        {
            _message = message;
        }

        public override void Operation()
        {
            Console.WriteLine(_message);
        }

        public override void Add(Component component)
        {
            _components.Add(component);
        }

        public override void Remove(Component component)
        {
            _components.Remove(component);
        }
    }
}