namespace Task3
{
    
    internal class MyStask
    {

        LinkedList<int> _stack;

        LinkedList<int> _minStack;

        public MyStask()
        {
            _stack = new LinkedList<int>();
            _minStack = new LinkedList<int>();
        }

        public void Add(int value)
        {
            _stack.AddLast(value);

            if (_minStack.Last == null)
            {
                _minStack.AddLast(value);
            } 
            else
            {
                _minStack.AddLast(Math.Min(_minStack.Last.Value, value));
            }
        }

        public void Pop()
        {
            _minStack.RemoveLast();
            _stack.RemoveLast();
        }

        public int GetMinValue()
        {
            if (_minStack.Last == null)
            {
                return 0;
            } 
            else
            {
                return _minStack.Last.Value;
            }
        }

    }

}
