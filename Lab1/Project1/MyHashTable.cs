using System.Collections.Generic;

namespace Task1
{

    internal class MyHashTable
    {

        private static int SIZE = 1000;

        private LinkedList<object>[] table;

        public MyHashTable()
        {
            this.table = new LinkedList<object>[SIZE];

            for (int i = 0; i < SIZE; i++)
            {
                this.table[i] = new LinkedList<object>();
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
                table[tableIndex].AddLast(obj);

                return true;
            }
        }

        public bool Remove(object obj)
        {
            int objectHash = obj.GetHashCode();
            int tableIndex = objectHash % SIZE;

            return table[tableIndex].Remove(obj);
        }

        public bool Contains(object obj)
        {
            int objectHash = obj.GetHashCode();
            int tableIndex = objectHash % SIZE;

            return table[tableIndex].Contains(obj);
        }

    }

}
