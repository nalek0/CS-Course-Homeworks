namespace Task1
{

    internal class MyHashTable
    {

        const int SIZE = 1000;

        LinkedList<object>[] _table;

        public MyHashTable()
        {
            _table = new LinkedList<object>[SIZE];

            for (int i = 0; i < SIZE; i++)
            {
                _table[i] = new LinkedList<object>();
            }
        }

        public bool Add(object obj)
        {
            if (Contains(obj))
            {
                return false;
            }
            else
            {
                int objectHash = obj.GetHashCode();
                int tableIndex = objectHash % SIZE;
                _table[tableIndex].AddLast(obj);

                return true;
            }
        }

        public bool Remove(object obj)
        {
            int objectHash = obj.GetHashCode();
            int tableIndex = objectHash % SIZE;

            return _table[tableIndex].Remove(obj);
        }

        public bool Contains(object obj)
        {
            int objectHash = obj.GetHashCode();
            int tableIndex = objectHash % SIZE;

            return _table[tableIndex].Contains(obj);
        }

    }

}
