using System;

namespace CompositeAndIterator
{
    public class Leaf : Component
    {
        private readonly string _message;

        public Leaf(string message)
        {
            _message = message;
        }

        public override void Operation()
        {
            Console.WriteLine(_message);
        }

        public override void Add(Component component)
        {
            
        }

        public override void Remove(Component component)
        {
            
        }
    }
}