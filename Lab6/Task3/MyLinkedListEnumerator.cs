using System.Collections;

namespace Task3;

public class MyLinkedListEnumerator<T> : IEnumerator<T>
{

    public T Current => (_current ?? throw new ArgumentException()).Value;


    object IEnumerator.Current => (_current ?? throw new ArgumentException()).Value;

    private Node<T>? _root;

    private Node<T>? _tail;

    private Node<T>? _current;

    public MyLinkedListEnumerator(Node<T>? root, Node<T>? tail)
    {
        this._root = root;
        this._tail = tail;
        this._current = null;
    }

    public bool MoveNext()
    {
        if (_root == null)
        {
            return false;
        }
        else
        {
            if (_current == _tail)
                return false;

            _current = _current == null ? _root : _current.Next;

            return true;
        }
    }

    public void Reset()
    {
        _current = null;
    }

    public void Dispose() {}
}
