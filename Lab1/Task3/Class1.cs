namespace Task3
{
    internal class MyStask
    {

        private LinkedList<int> stack;

        private LinkedList<int> minStack;

        public MyStask()
        {
            this.stack = new LinkedList<int>();
            this.minStack = new LinkedList<int>();
        }

        public void Add(int value)
        {
            stack.AddLast(value);

            if (minStack.Last == null)
            {
                minStack.AddLast(value);
            } else
            {
                minStack.AddLast(Math.Min(minStack.Last.Value, value));
            }
        }

        public void Pop()
        {
            minStack.RemoveLast();
            stack.RemoveLast();
        }

        public int GetMinValue()
        {
            if (minStack.Last == null)
            {
                return 0;
            } else
            {
                return minStack.Last.Value;
            }
        }

    }
}
