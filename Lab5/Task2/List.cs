using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

namespace Task2;

public class List<T>
{

    private Int32 _stacksLimit;

    private Stack<Stack<T>> _stacks;

    public List(Int32 limit = 4)
    {
        this._stacksLimit = limit;
        this._stacks = new Stack<Stack<T>>();
    }

    public void Push(T value)
    {
        if (_stacks.Count == 0)
            _stacks.Push(new Stack<T>());

        Stack<T> firstStack = _stacks.First();
        if (firstStack.Count == _stacksLimit)
            _stacks.Push(new Stack<T>());

        firstStack = _stacks.First();
        firstStack.Push(value);
    }

    public T Pop()
    {
        if (_stacks.Count == 0)
            throw new InvalidOperationException();
        else
        {
            T result = _stacks.First().Pop();

            if (_stacks.First().Count == 0)
                _stacks.Pop();

            return result;
        }
    }

    public Stack<Stack<T>> GetSubstacks()
    {
        return _stacks;
    }

}
