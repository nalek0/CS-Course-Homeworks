namespace Task1
{

    internal class MyHashTable {

        const int SIZE = 1000;

        List<object> _data;

        List<bool> _removed;

        public MyHashTable() {
            _data = new List<object>(SIZE);
            _removed = new List<bool>(SIZE);

            for (int i = 0; i < SIZE; i++) 
            {
                _data.Add(null);
                _removed.Add(false);
            }
        }

        public bool Add(object obj) {
            int counter = 0;
            int startIndex = obj.GetHashCode() % SIZE;

            while (counter < SIZE) {
                int currentIndex = (startIndex + counter) % SIZE;
                
                if (_data[currentIndex] == null || _removed[currentIndex])
                {
                    _data[currentIndex] = obj;
                    _removed[currentIndex] = false;

                    return true;
                }
                else
                {
                    counter++;
                }
            }

            return false;
        }

        public bool Remove(object obj) {
            int counter = 0;
            int startIndex = obj.GetHashCode() % SIZE;

            while (counter < SIZE) {
                int currentIndex = (startIndex + counter) % SIZE;
                
                if (_data[currentIndex] == null)
                {
                    return false;
                }
                else if (!_removed[currentIndex] && _data[currentIndex].Equals(obj)) 
                {
                    _removed[currentIndex] = true;

                    return true;
                }

                counter++;
            }

            return false;
        }

        public bool Contains(object obj) {
            int counter = 0;
            int startIndex = obj.GetHashCode() % SIZE;

            while (counter < SIZE) {
                int currentIndex = (startIndex + counter) % SIZE;
                
                if (_data[currentIndex] == null)
                {
                    return false;
                }
                else if (!_removed[currentIndex] && _data[currentIndex].Equals(obj)) 
                {
                    return true;
                }

                counter++;
            }

            return false;
        }

    }

}
