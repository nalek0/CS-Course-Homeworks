using System.Collections;
using System.Diagnostics;

namespace Task3;

public class MyLinkedList<T> : IEnumerable<T>
{

    private int _size;

    private Node<T>? _root;

    private Node<T>? _tail;

    public int Count => _size;

    public MyLinkedList()
    {
        this._size = 0;
        this._root = null;
        this._tail = null;
    }

    public void Add(T value)
    {
        if (_size == 0)
        {
            _root = new Node<T>(value);
            _tail = _root;
            _size++;
        }
        else
        {
            Debug.Assert(_tail != null && _root != null);

            var node = new Node<T>(value);
            _tail.Next = node;
            _tail = node;
            _size++;
        }
    }

    public bool Remove(T value)
    {
        if (_size == 0)
        {
            return false;
        }
        else
        {
            Debug.Assert(_tail != null && _root != null);

            Node<T>? previous = null;
            Node<T> current = _root;

            while (true)
            {
                if (Object.Equals(current.Value, value))
                {
                    if (previous == null)
                        _root = current.Next;
                    else
                        previous.Next = current.Next;

                    _size--;

                    if (_size == 0)
                    {
                        _root = null;
                        _tail = null;
                    }

                    return true;
                }
                else
                {
                    if (current.Next == null || current == _tail)
                        return false;

                    previous = current;
                    current = current.Next;
                }
            }
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new MyLinkedListEnumerator<T>(_root, _tail);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new MyLinkedListEnumerator<T>(_root, _tail);
    }

}
