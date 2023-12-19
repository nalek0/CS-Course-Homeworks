namespace Task3;

public class Node<T>
{

    public T Value { get; private set; }

    public Node<T>? Next { get; set; }

    public Node(T value)
    {
        this.Value = value;
        this.Next = null;
    }

    public Node(T value, Node<T> next)
    {
        this.Value = value;
        this.Next = next;
    }

}
