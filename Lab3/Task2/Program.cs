namespace Taks2
{

    public static class MainClass
    {

        private static MyNode? Intersection(MyLinkedList list1, MyLinkedList list2)
        {
            for (MyNode? current = list1.Root; current != null; current = current.Next)
            {
                current.Mark = false;
            }

            for (MyNode? current = list2.Root; current != null; current = current.Next)
            {
                current.Mark = false;
            }

            for (MyNode? current = list1.Root; current != null; current = current.Next)
            {
                current.Mark = true;
            }

            for (MyNode? current = list2.Root; current != null; current = current.Next)
            {
                if (current.Mark)
                {
                    return current;
                }
            }

            return null;
        }

        public static void Main()
        {
            MyNode tail = new MyNode("tail", null);
            MyNode result = new MyNode("result", tail);
            MyNode root1 = new MyNode("root1", result);
            MyNode extra = new MyNode("extra_node", result);
            MyNode root2 = new MyNode("root2", extra);

            MyLinkedList list1 = new MyLinkedList(root1);
            MyLinkedList list2 = new MyLinkedList(root2);

            MyNode? intersection1 = Intersection(list1, list1);
            Console.WriteLine(intersection1 == null ? "null" : intersection1.ToString());
            MyNode? intersection2 = Intersection(list2, list2);
            Console.WriteLine(intersection2 == null ? "null" : intersection2.ToString());
            MyNode? intersection3 = Intersection(list1, list2);
            Console.WriteLine(intersection3 == null ? "null" : intersection3.ToString());
            MyNode? intersection4 = Intersection(list2, list1);
            Console.WriteLine(intersection4 == null ? "null" : intersection4.ToString());
        }

    }

}
