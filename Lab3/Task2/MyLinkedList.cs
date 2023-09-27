namespace Taks2
{

    public sealed class MyNode
    {

        public String Label { get; }

        public MyNode? Next { get; }

        public bool Mark { get; set; }

        public MyNode(String label, MyNode? next)
        {
            this.Label = label;
            this.Next = next;
            this.Mark = false;
        }

        public override string ToString()
        {
            return "(" + Label + ")";
        }

    }

    public sealed class MyLinkedList
    {

        public MyNode Root { get; }

        public MyLinkedList(MyNode root)
        {
            this.Root = root;
        }

    }

}
