using System.Collections;
using System.Diagnostics;

namespace Task1;

public class Lake : IEnumerable<int>
{

    private int _size;

    public Lake(int size)
    {
        this._size = size;
    }

    public IEnumerator<int> GetEnumerator()
    {
        return new LakeEnumerator(_size);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }


    private class LakeEnumerator : IEnumerator<int>
    {

        private int _size;

        private int _current;

        public object Current
        {
            get
            {
                return _current;
            }
        }

        int IEnumerator<int>.Current
        {
            get
            {
                return _current;
            }
        }


        public LakeEnumerator(int size)
        {
            if (size <= 0)
                throw new ArgumentException();

            this._size = size;
            this._current = -1;
        }

        public void Dispose() { }

        public bool MoveNext()
        {
            if (_current == -1)
            {
                _current = 1;

                return true;
            }

            if (_current % 2 == 1)
            {
                if (_current + 2 <= _size)
                {
                    _current += 2;

                    return true;
                }
                else if (_current + 1 <= _size)
                {
                    _current++;

                    return true;
                }
                else if (_current > 1)
                {
                    _current--;

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (_current == 2)
                {
                    return false;
                }
                else
                {
                    _current -= 2;

                    return true;
                }
            }
        }

        public void Reset()
        {
            _current = -1;
        }

    }

}
